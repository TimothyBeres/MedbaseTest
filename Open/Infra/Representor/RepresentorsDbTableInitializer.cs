using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Text;
using Open.Data.Person;
using Open.Data.Representor;

namespace Open.Infra.Representor
{
    public static class RepresentorsDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Representors.Any()) return;
            initRepresentors(c);
            c.SaveChanges();
        }

        private static List<string> initRepresentors(SentryDbContext c)
        {
            var l = new List<string>
            {
                add(c, new RepresentorDbRecord
                {
                   Name = "Kevin",
                   Email = "kevinkoppel@windowslive.com"
                    
                
                }),

                add(c, new RepresentorDbRecord
                {
                    Name = "Tim",
                    Email = "kevinkoppel@hotmail.com"
                    
                }),
                add(c, new RepresentorDbRecord
                {
                    Name = "Marko",
                    Email = "kevinkoppel98@gmail.com"

                })
            };
            return l;
        }

        private static string add(SentryDbContext c, RepresentorDbRecord representor)
        {
            representor.ID = Guid.NewGuid().ToString();
            c.Representors.Add(representor);
            return representor.ID;
        }
    }
}
