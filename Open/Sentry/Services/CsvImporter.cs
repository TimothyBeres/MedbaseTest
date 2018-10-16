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
            var res = engine.ReadFile("C:\\Users\\kevin\\Desktop\\ravimidtest.csv");

            foreach (MedicineTemplate med in res)
            {
                AddMedicine(med);
                
            }

            
        }

        public static void AddMedicine(MedicineTemplate med)
        {
            
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO dbo.Medicine (ID,AtcCode,FormOfInjection,LegalStatus,Manufacturer,Name,Pil,Reimbursement,Spc,Strength,ValidFrom,ValidTo) VALUES (@ID,@AtcCode,@FormOfInjection,@LegalStatus,@Manufacturer,@Name,@Pil,@Reimbursement,@Spc,@Strength,@ValidFrom,@ValidTo)";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", CreateID());
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

        public static void AddEffect()
        {

        }

        public static void ClearMedicineTable()
        {
            
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "DELETE FROM dbo.Medicine";
            
            
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public static void ClearMedicineEffectsTable()
        {
            string _connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sentry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "DELETE FROM dbo.MedicineEffects";


            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        
    }
}