using System;
using System.Collections.Generic;
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
            foreach (var thing in res)
            {
                Console.WriteLine(thing);
            }
            foreach (MedicineTemplate med in res)
            {
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

        public static void AddMedicine()
        {

        }

        public static void AddEffect()
        {

        }
        
    }
}