using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FileHelpers;
using Open.Domain.Product;
using System.Linq;
using Microsoft.Extensions.Logging;
using Open.Infra;
using Open.Infra.Product;
using Open.Sentry1;
using PdfToText;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sentry1.Services
{
    public static class CsvImporter
    {
        public static void Importer(SentryDbContext c)
        {
            var legalRequirement = "R";
            var engine = new DelimitedFileEngine<MedicineTemplate>();
            //var res = engine.ReadFile("C:\\Users\\ACER\\Desktop\\projekt_ravim\\ravimid_3.csv");
            var res = engine.ReadFile("est_med.csv");
            List<MedicineTemplate> meds = new List<MedicineTemplate>();
            List<string> effectsList = new List<string>();
            foreach (MedicineTemplate med in res)
            {
                med.ValidFrom = DateTime.Today;
                //Valmisprogrammis ravimite lisamiseks:
                //if (med.LegalStatus != legalRequirement)
                //{
                //    meds.Add(med);
                //}
                meds.Add(med);
            }
            AddMedicines(meds);
        }
        public static void ParsePdf()
        {
            PDFParser pdfParser = new PDFParser();
            string address = @"http://ec.europa.eu/health/documents/community-register/html/h_direct_anx.htm#412_et";
            string outfile = "outfile.txt";
            bool result = pdfParser.ExtractText(address, outfile);
        }   
        public async static Task DownloadPdf()
        {
            //var wc = new System.Net.WebClient();
            //string url = @"http://ravimiregister.ravimiamet.ee/Data/PIL/PIL_1249006.pdf";
            //wc.DownloadFile(url, @"c:\Users\ACER\Desktop\myfile2.txt");

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://ravimiregister.ravimiamet.ee/Data/PIL/PIL_1249006.pdf");
            var pageContents = await response.Content.ReadAsStringAsync();
        }
        public static List<string> GetMedicineEffects(MedicineTemplate med)
        {
            List<string> effectsList = new List<string>();
            var effecto = med.Effects.Replace("\"", "");
            if (effecto.Contains("+"))
            {
                string[] effects = effecto.Split(" +");
                foreach (string effect in effects)
                {
                    effectsList.Add(effect);
                }
            }
            else
            {
                effectsList.Add(effecto);
            }
            return effectsList;
        }
        public static void AddMedicineEffect(Guid medicineId, Guid effectId, MedicineTemplate med, SqlConnection connection)
        {
            string query = "INSERT INTO dbo.MedicineEffects (MedicineID,EffectID,ValidFrom,ValidTo) VALUES (@MedicineID,@EffectID,@ValidFrom,@ValidTo)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                 command.Parameters.AddWithValue("@MedicineID", medicineId);
                 command.Parameters.AddWithValue("@EffectID", effectId);
                 command.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                 command.Parameters.AddWithValue("@ValidTo", med.ValidTo);
                 command.ExecuteNonQuery();
            }  
        }
        public static void AddMedicines(List<MedicineTemplate> meds)
        {
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var med in meds)
                {
                    Guid id = CreateID();
                    bool exists = MedicineInDb(med.Name, med.FormOfInjection, med.Strength, connection);
                    string query = "INSERT INTO dbo.Medicine (ID,AtcCode,FormOfInjection,LegalStatus,Manufacturer,Name,Pil,Reimbursement,Spc,Strength,ValidFrom,ValidTo) VALUES (@ID,@AtcCode,@FormOfInjection,@LegalStatus,@Manufacturer,@Name,@Pil,@Reimbursement,@Spc,@Strength,@ValidFrom,@ValidTo)";
                    if (!exists)
                    {

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", id);
                            command.Parameters.AddWithValue("@AtcCode", med.AtcCode.Replace("\"", ""));
                            command.Parameters.AddWithValue("@FormOfInjection", med.FormOfInjection.Replace("\"", ""));
                            command.Parameters.AddWithValue("@LegalStatus", med.LegalStatus.Replace("\"", ""));
                            command.Parameters.AddWithValue("@Manufacturer", med.Manufacturer.Replace("\"", ""));
                            command.Parameters.AddWithValue("@Name", med.Name.Replace("\"", ""));
                            command.Parameters.AddWithValue("@Pil", med.Pil.Replace("\"", ""));
                            command.Parameters.AddWithValue("@Reimbursement", med.Reimbursement.Replace("\"", ""));
                            command.Parameters.AddWithValue("@Spc", med.Spc.Replace("\"", ""));
                            command.Parameters.AddWithValue("@Strength", med.Strength.Replace("\"", ""));
                            command.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                            command.Parameters.AddWithValue("@ValidTo", med.ValidTo);
                            command.ExecuteNonQuery();
                        }
                        List<string> effects = GetMedicineEffects(med);
                        List<Guid> effectIds = new List<Guid>();
                        foreach (var e in effects)
                        {
                            var effectId = AddEffect(med, e, connection);
                            effectIds.Add(effectId);
                        }

                        foreach (var efId in effectIds)
                        {
                            bool medEffExists = MedicineEffectInDb(efId, id, connection);
                            if (!medEffExists)
                            {
                                AddMedicineEffect(id, efId, med, connection);
                            }
                            
                        }
                    }                    
                }  
            }
        }

        private static Guid CreateID()
        {
            Guid ID = Guid.NewGuid();
            return ID;
        }
        public static Guid AddEffect(MedicineTemplate med, string name, SqlConnection connection)
        {
            Guid id = CreateID();
            string query = "INSERT INTO dbo.Effect (ID,Name,ValidFrom,ValidTo) VALUES (@ID,@Name,@ValidFrom,@ValidTo) ";
            bool exists = EffectInDb(name, connection);
            if (!exists)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                    command.Parameters.AddWithValue("@ValidTo", med.ValidTo);
                    command.ExecuteNonQuery();
                }
                return id;
            }
            else
            {
                string newQuery = "SELECT ID FROM[Effect] WHERE([Name] = @Name)";
                using (SqlCommand get_effect = new SqlCommand(newQuery, connection))
                {
                    get_effect.Parameters.AddWithValue("@Name", name);
                    var stringId = get_effect.ExecuteScalar().ToString();
                    Guid returnedId = Guid.Parse(stringId);
                    return returnedId;
                }
            }
            
        }
        public static void ClearMedicinesAndEffects()
        {
            string query1 = "DELETE FROM dbo.Medicine";
            string query2 = "DELETE FROM dbo.MedicineEffects";
            string query3 = "DELETE FROM dbo.Effect";
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                connection.Open();
                using (SqlCommand cmd1 = new SqlCommand(query2, connection))
                {
                    cmd1.ExecuteNonQuery();
                }

                using (SqlCommand cmd2 = new SqlCommand(query1, connection))
                {
                    cmd2.ExecuteNonQuery();
                }

                using (SqlCommand cmd3 = new SqlCommand(query3, connection))
                {
                    cmd3.ExecuteNonQuery();
                }
            }


        }

        public static bool MedicineInDb(string medName, string medInj, string medStr, SqlConnection connection)
        {

            string query = "SELECT COUNT(*) FROM [Medicine] WHERE ([Name] = @Name) AND ([FormOfInjection] = @FormOfInjection) AND ([Strength] = @Strength)";
            using (SqlCommand check_medicine = new SqlCommand(query, connection))
            {
                check_medicine.Parameters.AddWithValue("@Name", medName.Replace("\"", ""));
                check_medicine.Parameters.AddWithValue("@FormOfInjection", medInj.Replace("\"", ""));
                check_medicine.Parameters.AddWithValue("@Strength", medStr.Replace("\"", ""));
                int UserExist = (int)check_medicine.ExecuteScalar();

                if (UserExist > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }       
            }                                    
        }
        public static bool EffectInDb(string effectName, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM [Effect] WHERE ([Name] = @Name)";
            using (SqlCommand check_effect = new SqlCommand(query, connection))
            {
                check_effect.Parameters.AddWithValue("@Name", effectName.Replace("\"", ""));
                int UserExist = (int)check_effect.ExecuteScalar();

                if (UserExist > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool MedicineEffectInDb(Guid effectId, Guid medicineId, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM [MedicineEffects] WHERE ([MedicineID] = @MedicineID) AND ([EffectID] = @EffectID)";
            using (SqlCommand check_medeffect = new SqlCommand(query, connection))
            {
                check_medeffect.Parameters.AddWithValue("@MedicineID", medicineId);
                check_medeffect.Parameters.AddWithValue("@EffectID", effectId);
                int UserExist = (int)check_medeffect.ExecuteScalar();

                if (UserExist > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}