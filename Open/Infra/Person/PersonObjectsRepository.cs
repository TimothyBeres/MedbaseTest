using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Person;
using Open.Domain.Person;

namespace Open.Infra.Person
{
    public class PersonObjectsRepository : ObjectsRepository<PersonObject, PersonDbRecord>,
        IPersonObjectsRepository
    {
        public PersonObjectsRepository(SentryDbContext c) : base(c?.Persons, c) { }

        protected internal override PersonObject createObject(PersonDbRecord r)
        {
            return new PersonObject(r);
        }

        protected internal override PaginatedList<PersonObject> createList(
            List<PersonDbRecord> l, RepositoryPage p)
        {
            return new PersonObjectsList(l, p);
        }
        public async Task<PersonObject> GetPersonByIDCode(string id_code)
        {
            var allPersons = await GetObjectsList();
            var persons = allPersons.Where(x => x.DbRecord.IDCode == id_code);
            var list = new List<PersonDbRecord>();
            foreach (var i in persons)
            {
                list.Add(i.DbRecord);
            }
            return createObject(list[0]);
            
        }

    }
}
