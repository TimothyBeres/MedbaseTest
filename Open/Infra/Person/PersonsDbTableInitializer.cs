using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Person;

namespace Open.Infra.Person
{
    public static class PersonsDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Persons.Any()) return;
            initPersons(c);
            c.SaveChanges();
        }

        private static List<string> initPersons(SentryDbContext c)
        {
            var l = new List<string>
            {
                add(c, new PersonDbRecord
                {
                    IDCode = "39010101234",
                    FirstName = "Jaan",
                    LastName = "Kask"
                }),

                add(c, new PersonDbRecord
                {
                    IDCode = "49011114321",
                    FirstName = "Anu",
                    LastName = "Raud"
                })
            };
            return l;
        }

        private static string add(SentryDbContext c, PersonDbRecord person)
        {
            person.ID = Guid.NewGuid().ToString();
            c.Persons.Add(person);
            return person.ID;
        }
    }
}