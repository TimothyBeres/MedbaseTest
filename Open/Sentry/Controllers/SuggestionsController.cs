using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Product;
using Open.Data.Person;
using Open.Domain.Person;
using Open.Domain.Product;
using Open.Facade.Product;
using Open.Facade.Person;
using Sentry1.Models;

namespace Open.Sentry1.Controllers
{
    public class SuggestionsController : Controller
    {
        private readonly IMedicineObjectsRepository repository;
        private readonly IPersonObjectsRepository personRepository;
        private readonly IPersonObjectsRepository persons;
        private readonly IPersonMedicineObjectsRepository personMedicines;
        public const string properties = "ID, FirstName, LastName, ValidFrom, ValidTo";

        public SuggestionsController(IPersonObjectsRepository p, IPersonMedicineObjectsRepository pm, IPersonObjectsRepository pr)
        {
            persons = p;
            personMedicines = pm;
            personRepository = pr;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PatientInfo(PersonViewModel model)
        {
            var idCode = model.IDCode;
            var persona = await persons.GetPersonByIDCode(idCode);
            await personMedicines.LoadMedicines(persona);
            return View("PatientInfo", PersonViewModelFactory.Create(persona));
        }
        /*public async Task<IActionResult> PatientInfo(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SortAtcCode"] = sortOrder == "atc_code" ? "atc_code_desc" : "atc_code";
            ViewData["SortFormOfInjection"] =
                sortOrder == "form_of_injection" ? "form_of_injection_desc" : "form_of_injection";
            ViewData["SortStrength"] = sortOrder == "strength" ? "strength_desc" : "strength";
            ViewData["SortManufacturer"] = sortOrder == "manufacturer" ? "manufacturer_desc" : "manufacturer";
            ViewData["SortLegalStatus"] = sortOrder == "legal_status" ? "legal_status_desc" : "legal_status";
            ViewData["SortReimbursement"] = sortOrder == "reimbursement" ? "reimbursement_desc" : "reimbursement";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";

            repository.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            repository.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            repository.SearchString = searchString;
            repository.PageIndex = page ?? 1;
            var l = await repository.GetObjectsList();
            return View(new MedicineViewModelsList(l));
        }*/

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] PersonViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = PersonObjectFactory.Create(c.ID, c.IDCode, c.FirstName, c.LastName, c.ValidFrom, c.ValidTo);
            await personRepository.AddObject(o);
            return RedirectToAction("PatientInfo");
        }

        private Func<MedicineDbRecord, object> getSortFunction(string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("atc_code")) return x => x.AtcCode;
            if (sortOrder.StartsWith("form_of_injection")) return x => x.FormOfInjection;
            if (sortOrder.StartsWith("strength")) return x => x.Strength;
            if (sortOrder.StartsWith("manufacturer")) return x => x.Manufacturer;
            if (sortOrder.StartsWith("legal_status")) return x => x.LegalStatus;
            if (sortOrder.StartsWith("reimbursement")) return x => x.Reimbursement;

            return x => x.Name;
        }
    }
}
