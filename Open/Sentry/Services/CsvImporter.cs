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

namespace Sentry1.Services
{
    public static class CsvImporter
    {
        public static void Importer(SentryDbContext c)
        {

            var engine = new DelimitedFileEngine<MedicineTemplate>();
            var res = engine.ReadFile("ravimidtest.csv");


            foreach (MedicineTemplate med in res)
            {
                Guid medicineId = CreateID();
                Guid effectId = CreateID();
                AddMedicine(med, medicineId);
                if (med.Effects.Contains("+"))
                {
                    string[] effects = med.Effects.Split(" +");
                    foreach (string effect in effects)
                    {

                        AddEffectWithPlusSign(med, effect, medicineId);

                    }

                }
                else
                {

                    AddEffect(med, effectId);
                    AddMedicineEffect(medicineId, effectId, med);
                }



            }


        }

        public static void AddMedicineEffect(Guid medicineId, Guid effectId, MedicineTemplate med)
        {
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.MedicineEffects (MedicineID,EffectID,ValidFrom,ValidTo) VALUES (@MedicineID,@EffectID,@ValidFrom,@ValidTo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MedicineID", medicineId);
                    command.Parameters.AddWithValue("@EffectID", effectId);
                    command.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                    command.Parameters.AddWithValue("@ValidTo", med.ValidTo);




                    connection.Open();
                    command.ExecuteNonQuery();

                    // Check Error

                }
            }
        }

        public static void AddMedicine(MedicineTemplate med, Guid id)
        {

            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.Medicine (ID,AtcCode,FormOfInjection,LegalStatus,Manufacturer,Name,Pil,Reimbursement,Spc,Strength,ValidFrom,ValidTo) VALUES (@ID,@AtcCode,@FormOfInjection,@LegalStatus,@Manufacturer,@Name,@Pil,@Reimbursement,@Spc,@Strength,@ValidFrom,@ValidTo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@AtcCode", med.AtcCode);
                    command.Parameters.AddWithValue("@FormOfInjection", med.FormOfInjection);
                    command.Parameters.AddWithValue("@LegalStatus", med.LegalStatus);
                    command.Parameters.AddWithValue("@Manufacturer", med.Manufacturer);
                    command.Parameters.AddWithValue("@Name", med.Name);
                    command.Parameters.AddWithValue("@Pil", med.Pil);
                    command.Parameters.AddWithValue("@Reimbursement", med.Reimbursement);
                    command.Parameters.AddWithValue("@Spc", med.Spc);
                    command.Parameters.AddWithValue("@Strength", med.Strength);
                    command.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                    command.Parameters.AddWithValue("@ValidTo", med.ValidTo);



                    connection.Open();
                    command.ExecuteNonQuery();

                    // Check Error

                }
            }
        }

        private static Guid CreateID()
        {
            Guid ID = Guid.NewGuid();
            return ID;
        }
        public static void AddEffect(MedicineTemplate med, Guid id)
        {
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.Effect (ID,Name,ValidFrom,ValidTo) VALUES (@ID,@Name,@ValidFrom,@ValidTo) ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", med.Effects);
                    command.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                    command.Parameters.AddWithValue("@ValidTo", med.ValidTo);



                    connection.Open();
                    command.ExecuteNonQuery();

                    // Check Error

                }
            }
        }

        public static void AddEffectWithPlusSign(MedicineTemplate med, string name, Guid medId)
        {
            Guid id = CreateID();
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query1 = "INSERT INTO dbo.Effect (ID,Name,ValidFrom,ValidTo) VALUES (@ID,@Name,@ValidFrom,@ValidTo) ";
                string query2 =
                    "INSERT INTO dbo.MedicineEffects (MedicineID,EffectID,ValidFrom,ValidTo) VALUES (@MedicineID,@EffectID,@ValidFrom,@ValidTo)";
                connection.Open();
                using (SqlCommand command1 = new SqlCommand(query1, connection))
                {
                    command1.Parameters.AddWithValue("@ID", id);
                    command1.Parameters.AddWithValue("@Name", name);
                    command1.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                    command1.Parameters.AddWithValue("@ValidTo", med.ValidTo);




                    command1.ExecuteNonQuery();

                    // Check Error

                }

                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {
                    command2.Parameters.AddWithValue("@MedicineID", medId);
                    command2.Parameters.AddWithValue("@EffectID", id);
                    command2.Parameters.AddWithValue("@ValidFrom", med.ValidFrom);
                    command2.Parameters.AddWithValue("@ValidTo", med.ValidTo);

                    command2.ExecuteNonQuery();
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



    }
}