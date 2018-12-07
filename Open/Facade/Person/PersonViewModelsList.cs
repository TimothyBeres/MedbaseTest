using System.Collections.Generic;
using System.Linq;
using Open.Core;
using Open.Domain.Person;

namespace Open.Facade.Person
{
    public class PersonViewModelsList : PaginatedList<PersonViewModel>
    {
        public PersonViewModelsList(IPaginatedList<PersonObject> list, string sortOrder = null)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            var catalogues = new List<PersonViewModel>();
            IOrderedEnumerable<PersonViewModel> ordered;
            foreach (var e in list)
            {
                catalogues.Add(PersonViewModelFactory.Create(e));
            }
            switch (sortOrder)
            {
                case "firstName_desc":
                    ordered = catalogues.OrderByDescending(s => s.FirstName);
                    break;
                case "lastName":
                    ordered = catalogues.OrderBy(s => s.LastName);
                    break;
                case "lastName_desc":
                    ordered = catalogues.OrderByDescending(s => s.LastName);
                    break;
                case "idcode":
                    ordered = catalogues.OrderBy(s => s.IDCode);
                    break;
                case "idcode_desc":
                    ordered = catalogues.OrderByDescending(s => s.IDCode);
                    break;
                case "validFrom":
                    ordered = catalogues.OrderBy(s => s.ValidFrom);
                    break;
                case "validFrom_desc":
                    ordered = catalogues.OrderByDescending(s => s.ValidFrom);
                    break;
                case "validTo":
                    ordered = catalogues.OrderBy(s => s.ValidTo);
                    break;
                case "validTo_desc":
                    ordered = catalogues.OrderByDescending(s => s.ValidTo);
                    break;
                default:
                    ordered = catalogues.OrderBy(s => s.FirstName);
                    break;
            }
            AddRange(ordered);
        }
    }
}