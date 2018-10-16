using System.Collections.Generic;
using Open.Core;
using Open.Data.Person;

namespace Open.Domain.Person
{
    public class PersonObjectsList : PaginatedList<PersonObject>
    {
        public PersonObjectsList(IEnumerable<PersonDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new PersonObject(dbRecord));
            }
        }
    }
}