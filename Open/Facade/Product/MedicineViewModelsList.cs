using System.Collections.Generic;
using System.Linq;
using Open.Core;
using Open.Domain.Product;

namespace Open.Facade.Product
{
    public class MedicineViewModelsList : PaginatedList<MedicineViewModel>
    {
        public MedicineViewModelsList(IPaginatedList<MedicineObject> list, string sortOrder = null)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            var catalogues = new List<MedicineViewModel>();
            IOrderedEnumerable<MedicineViewModel> ordered;
            foreach (var e in list)
            {
                catalogues.Add(MedicineViewModelFactory.Create(e));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ordered = catalogues.OrderByDescending(s => s.Name);
                    break;
                case "atc_code":
                    ordered = catalogues.OrderBy(s => s.AtcCode);
                    break;
                case "atc_code_desc":
                    ordered = catalogues.OrderByDescending(s => s.AtcCode);
                    break;
                case "form_of_injecton":
                    ordered = catalogues.OrderBy(s => s.FormOfInjection);
                    break;
                case "form_of_injecton_desc":
                    ordered = catalogues.OrderByDescending(s => s.FormOfInjection);
                    break;
                case "strength":
                    ordered = catalogues.OrderBy(s => s.Strength);
                    break;
                case "strength_desc":
                    ordered = catalogues.OrderByDescending(s => s.Strength);
                    break;
                case "manufacturer":
                    ordered = catalogues.OrderBy(s => s.Manufacturer);
                    break;
                case "manufacturer_desc":
                    ordered = catalogues.OrderByDescending(s => s.Manufacturer);
                    break;
                case "legal_status":
                    ordered = catalogues.OrderBy(s => s.LegalStatus);
                    break;
                case "legal_status_desc":
                    ordered = catalogues.OrderByDescending(s => s.LegalStatus);
                    break;
                case "reimbursement":
                    ordered = catalogues.OrderBy(s => s.Reimbursement);
                    break;
                case "reimbursement_desc":
                    ordered = catalogues.OrderByDescending(s => s.Reimbursement);
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
                    ordered = catalogues.OrderBy(s => s.Name);
                    break;
            }
            AddRange(ordered);
        }
    }
}