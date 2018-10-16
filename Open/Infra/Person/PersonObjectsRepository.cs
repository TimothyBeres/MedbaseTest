using System.Collections.Generic;
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
    }
}
