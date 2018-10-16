using System.Collections.Generic;
using System.Linq;
using Open.Core;
using Open.Domain.Person;

namespace Open.Facade.Person
{
    public class PersonViewModelsList : PaginatedList<PersonViewModel>
    {
        public PersonViewModelsList(IPaginatedList<PersonObject> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            var catalogues = new List<PersonViewModel>();
            foreach (var e in list)
            {
                catalogues.Add(PersonViewModelFactory.Create(e));
            }
        }
    }
}