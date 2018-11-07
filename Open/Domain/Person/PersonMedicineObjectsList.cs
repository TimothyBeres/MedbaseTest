using System.Collections.Generic;
using Open.Core;
using Open.Data.Person;

namespace Open.Domain.Person
{
    public class PersonMedicineObjectsList : PaginatedList<PersonMedicineObject>
    {
        public PersonMedicineObjectsList(IEnumerable<PersonMedicineDbRecord> items,
            RepositoryPage page) :
            base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new PersonMedicineObject(dbRecord));
            }
        }
    }
}