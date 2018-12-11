using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Open.Core;
using Open.Data.Product;
using Open.Data.Person;
using Open.Domain.Location;
using Open.Domain.Person;
using Open.Domain.Process;
using Open.Domain.Product;
using Open.Facade.Location;
using Open.Facade.Product;
using Open.Facade.Person;
using Open.Facade.Process;
using Sentry1.Models;

namespace Open.Sentry1.Controllers
{
    public class SuggestionsController : Controller
    {
        private readonly IMedicineObjectsRepository medicines;
        private readonly IPersonObjectsRepository persons;
        private readonly IPersonMedicineObjectsRepository personMedicines;
        private readonly IDosageObjectsRepository dosages;
        private readonly ISchemeObjectsRepository schemes;
        public const string properties = "ID, IDCode, FirstName, LastName, ValidFrom, ValidTo";
        internal const string sugProperties =
            "ID, MedicineID, TypeOfTreatment, Length, Amount, Times, TimeOfDay, UsedMedicine, ValidFrom, ValidTo";

        public SuggestionsController(IPersonObjectsRepository p, IPersonMedicineObjectsRepository pm, IMedicineObjectsRepository m,
            IDosageObjectsRepository d, ISchemeObjectsRepository s)
        {
            persons = p;
            personMedicines = pm;
            medicines = m;
            dosages = d;
            schemes = s;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PatientInfo(PersonViewModel model)
        {
            var idCode = model.IDCode;
            try
            {
                var persona = await persons.GetPersonByIDCode(idCode);

                await personMedicines.LoadMedicines(persona);
                var personView = PersonViewModelFactory.Create(persona);
                var personSuggestions = await dosages.GetAllDosages(persona.DbRecord.ID);
                foreach (var sug in personSuggestions)
                {
                    var pm = await personMedicines.GetObject(sug.DbRecord.MedicineID, persona.DbRecord.ID);
                    var med = await medicines.GetObject(sug.DbRecord.MedicineID);
                    personView.SuggestionsMade.Add(PersonInfoViewModelFactory.Create(sug, pm, med));
                }
                return View("PatientInfo", personView);
            }
            catch (Exception e)
            {
                ViewBag.Message = "Sellise id-koodiga inimene puudub!";
                return View("Index");
            }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DosageScheme([Bind(sugProperties)]SuggestionViewModel s, string medicineId)
        {
            string suitable;
            if (!ModelState.IsValid) return View(s);
            var currentDate = DateTime.Now;
            var untilDate = currentDate.AddDays(double.Parse(s.Length));
            var dosageId = Guid.NewGuid().ToString();
            var schemeId = Guid.NewGuid().ToString();
            var perObj = await persons.GetPersonByIDCode(s.ID);
            var medObj = await medicines.GetObject(medicineId);
            var dosage = DosageObjectFactory.Create(dosageId, s.TypeOfTreatment, perObj.DbRecord.ID,s.MedicineID, currentDate, untilDate);
            var scheme = SchemeObjectsFactory.Create(schemeId, dosageId, "1", s.Length, s.Amount, s.Times, s.TimeOfDay, currentDate, untilDate);
            var o = await personMedicines.GetObject(medicineId, perObj.DbRecord.ID);
            if (o.DbRecord.MedicineID == "Unspecified")
            {
                suitable = "Teadmata";
            }
            else
            {
                suitable = "Jah";
                await personMedicines.DeleteObject(o);
            }
            await personMedicines.AddObject(PersonMedicineObjectFactory.Create(perObj, medObj, suitable, currentDate));
            await dosages.AddObject(dosage);
            await schemes.AddObject(scheme);
            return RedirectToAction("PatientInfo", PersonViewModelFactory.Create(perObj));
        }
        public async Task<IActionResult> DosageScheme(string id,
            string currentFilter = null,
            string searchString = null,
            int? page = null,
            string medId = null)
        {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            medicines.SearchString = searchString;
            medicines.PageIndex = page ?? 1;
            medicines.PageSize = 1000000;
            var meds = new MedicineViewModelsList(null);
            if (!string.IsNullOrWhiteSpace(searchString))
                meds = new MedicineViewModelsList(await medicines.GetObjectsList());
            var dosagesSch = SuggestionViewModelFactory.Create(id);
            if (medId != null)
            {
                dosagesSch.UsedMedicine = MedicineViewModelFactory.Create(await medicines.GetObject(medId));
                meds.RemoveAll(x => x.ID == medId);
                dosagesSch.MedicineID = medId;
            }
            
            var l = await medicines.GetObjectsList();
            //ViewBag.Medicines = meds;
            ViewBag.Medicines = l.Select(x => new SelectListItem {
                Value = x.DbRecord.ID,
                Text = x.DbRecord.Name
            }).ToList();

            return View(dosagesSch);
        }

        public async Task<IActionResult> SendEmail(PersonViewModel c)
        {
            return null;
        }
        public async Task<IActionResult> RemoveMedicine(string personId, string medicineId)
        {
            return RedirectToAction("DosageScheme", new { id = personId });
        }

        public async Task<IActionResult> AddMedicine(string personId, string medicineId)
        {
            return RedirectToAction("DosageScheme", new { id = personId, medId = medicineId });
        }
    }
}
