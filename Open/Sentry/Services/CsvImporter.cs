using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FileHelpers;
using Open.Domain.Product;
using System.Linq;
using Open.Infra;
using Open.Infra.Product;

namespace Sentry1.Services
{
    public static class CsvImporter 
    {
        public static void Importer(SentryDbContext c)
        {
            var engine = new FileHelperEngine<MedicineTemplate>();
            var res = engine.ReadFile("ravimid.csv");
            
            foreach (MedicineTemplate med in res)
            {
                AddMedicine(med);
                var effects = new List<string>();
                
                if (med.Effects.Contains("+"))
                {
                    effects = med.Effects.Split("+").ToList();
                }

                foreach (string effect in effects)
                {
                    
                }
            }

            Console.ReadLine();
        }

        public static void AddMedicine(MedicineTemplate med)
        {
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.Medicine (AtcCode,FormOfInjection,LegalStatus,Manufacturer,Name,Pil,Reimbursement,Spc,Strength,ValidFrom,ValidTo) VALUES (@AtcCode,@FormOfInjection,@LegalStatus,@Manufacturer,@Name,@Pil,@Reimbursement,@Spc,@Strength,@ValidFrom,@ValidTo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }

        public static void AddEffect()
        {

        }
        
    }
}