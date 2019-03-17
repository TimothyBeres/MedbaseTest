using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Person;
using Open.Domain.Process;
using Open.Domain.Product;
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
        private readonly IEffectObjectsRepository effects;
        private readonly IMedicineEffectsObjectsRepository medEffects;
        private readonly IPortfolioObjectsRepository portfolio;
        private readonly UserManager<ApplicationUser> manager;
        public const string properties = "ID, IDCode, FirstName, LastName, ValidFrom, ValidTo";
        internal const string sugProperties =
            "ID, MedicineID, TypeOfTreatment, Length, Amount, Times, TimeOfDay, UsedMedicine, ValidFrom, ValidTo";

        internal const string patientInfoProperties =
            "ID, MedicineID, DosageID, Suitability, MedicineName, FormOfInjection";

        public SuggestionsController(IPersonObjectsRepository p, IPersonMedicineObjectsRepository pm, IMedicineObjectsRepository m,
            IDosageObjectsRepository d, ISchemeObjectsRepository s, IEffectObjectsRepository e, IMedicineEffectsObjectsRepository me,
            IPortfolioObjectsRepository port, UserManager<ApplicationUser> man)
        {
            persons = p;
            personMedicines = pm;
            medicines = m;
            dosages = d;
            schemes = s;
            effects = e;
            medEffects = me;
            portfolio = port;
            manager = man;
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
                PersonObject persona;
                if (model.ID != Constants.Unspecified)
                {
                    persona = await persons.GetObject(model.ID);
                }
                else
                {
                    persona = await persons.GetPersonByIDCode(idCode);
                }


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
        public async Task<IActionResult> Edit(Dictionary<string, string> d)
        {
            var personMed = await personMedicines.GetObject(d["medId"], d["perId"]);
            var dosage = await dosages.GetObject(d["dosId"]);
            var medicine = await medicines.GetObject(d["medId"]);
            return View(PersonInfoViewModelFactory.Create(dosage, personMed, medicine));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(patientInfoProperties)] PersonInfoViewModel c)
        {
            var currentDate = DateTime.Now;
            if (!ModelState.IsValid) return View(c);
            var personMed = await personMedicines.GetObject(c.MedicineID, c.ID);
            var perObj = await persons.GetObject(c.ID);
            var dosObj = await dosages.GetObject(c.DosageID);
            dosObj.DbRecord.Description = c.Description;

            if (personMed.DbRecord.Suitability != c.Suitability)
            {
                await personMedicines.DeleteObject(personMed);
                var medObj = await medicines.GetObject(c.MedicineID);
                await personMedicines.AddObject(PersonMedicineObjectFactory.Create(perObj, medObj, c.Suitability, currentDate));
            }
            //await dosages.UpdateObject(dosObj);
            return RedirectToAction("PatientInfo", PersonViewModelFactory.Create(perObj));
        }
        private Func<MedicineDbRecord, object> getSortFunctionMedicine(string sortOrder)
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
        public async Task<IActionResult> DosageScheme([Bind(sugProperties)]SuggestionViewModel s, string medicineId, string button)
        {
            Suitability suitable;
            var perObj = await persons.GetPersonByIDCode(s.ID);
            if (button != "prior")
            {
                bool suitableMed = await CheckMedicineSuitability(perObj.DbRecord.ID, medicineId);
                if (!suitableMed)
                {
                    var messageContent = await FindConflict(perObj.DbRecord.ID, medicineId);
                    ViewBag.Dictionary = messageContent;
                    ModelState.AddModelError(string.Empty, "");
                    ViewBag.AfterError = true;
                    await SetPropertiesMedicine(s.ID);
                    ViewBag.DefaultMedicine = s.MedicineID;
                }
            }
            if (!ModelState.IsValid) return View(s);

            if (medicineId.Length == 11)
            {
                var tempId = medicineId;
                medicineId = s.ID;
                s.ID = tempId;
            }
            var currentDate = DateTime.Now;
            var untilDate = currentDate.AddDays(double.Parse(s.Length));
            var dosageId = Guid.NewGuid().ToString();
            var schemeId = Guid.NewGuid().ToString();

            var medObj = await medicines.GetObject(medicineId);
            var dosage = DosageObjectFactory.Create(dosageId, s.TypeOfTreatment, perObj.DbRecord.ID, s.MedicineID, currentDate, untilDate);
            var scheme = SchemeObjectFactory.Create(schemeId, dosageId, "1", s.Length, s.Amount, s.Times, s.TimeOfDay, currentDate, untilDate);
            var o = await personMedicines.GetObject(medicineId, perObj.DbRecord.ID);
            if (o.DbRecord.MedicineID == "Unspecified")
            {
                suitable = Suitability.Teadmata;
            }
            else
            {
                suitable = Suitability.Jah;
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
            //var meds = new MedicineViewModelsList(null);
            //if (!string.IsNullOrWhiteSpace(searchString))
            //    meds = new MedicineViewModelsList(await medicines.GetObjectsList());

            //if (medId != null)
            //{
            //    dosagesSch.UsedMedicine = MedicineViewModelFactory.Create(await medicines.GetObject(medId));
            //    meds.RemoveAll(x => x.ID == medId);
            //    dosagesSch.MedicineID = medId;
            //}
            var dosagesSch = SuggestionViewModelFactory.Create(id);
            await SetPropertiesMedicine(id);
            ViewBag.AfterError = false;
            return View(dosagesSch);
        }
       
        public async Task<IActionResult> DosageSchemeMed(string id,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            persons.SearchString = searchString;
            persons.PageIndex = page ?? 1;
            persons.PageSize = 1000000;
            var pers = new PersonViewModelsList(null);
            var l = await persons.GetObjectsList();
            if (!string.IsNullOrWhiteSpace(searchString))
                pers = new PersonViewModelsList(l);
            var dosagesSch = SuggestionViewModelFactory.Create(id);
            await SetPropertiesPerson(id);
            ViewBag.AfterError = false;
            return View(dosagesSch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DosageSchemeMed([Bind(sugProperties)]SuggestionViewModel s, string personId, string button)
        {
            Suitability suitable;
            var medicineId = s.ID;
            var perObj = await persons.GetObject(personId);
            if (button != "prior")
            {
                bool suitableMed = await CheckMedicineSuitability(personId, medicineId);
                if (!suitableMed)
                {
                    var messageContent = await FindConflict(personId, medicineId);
                    ViewBag.Dictionary = messageContent;
                    ModelState.AddModelError(string.Empty, "");
                    ViewBag.AfterError = true;
                    await SetPropertiesPerson(medicineId);
                    ViewBag.DefaultPerson = personId;
                }
            }
            if (!ModelState.IsValid) return View(s);

            var currentDate = DateTime.Now;
            var untilDate = currentDate.AddDays(double.Parse(s.Length));
            var dosageId = Guid.NewGuid().ToString();
            var schemeId = Guid.NewGuid().ToString();
            var medObj = await medicines.GetObject(medicineId);
            var dosage = DosageObjectFactory.Create(dosageId, s.TypeOfTreatment, personId, medicineId, currentDate, untilDate);
            var scheme = SchemeObjectFactory.Create(schemeId, dosageId, "1", s.Length, s.Amount, s.Times, s.TimeOfDay, currentDate, untilDate);
            var o = await personMedicines.GetObject(medicineId, personId);
            if (o.DbRecord.MedicineID == "Unspecified")
            {
                suitable = Suitability.Teadmata;
            }
            else
            {
                suitable = Suitability.Jah;
                await personMedicines.DeleteObject(o);
            }
            await personMedicines.AddObject(PersonMedicineObjectFactory.Create(perObj, medObj, suitable, currentDate));
            await dosages.AddObject(dosage);
            await schemes.AddObject(scheme);
            return RedirectToAction("PatientInfo", PersonViewModelFactory.Create(perObj));
        }
        [HttpPost]
        public async Task<IActionResult> SendInfo(PersonInfoViewModel c)
        {
            var person = await persons.GetObject(c.ID);
            var informationPreference = person.DbRecord.GetMedicineInfo;
            var medicine = await medicines.GetObject(c.MedicineID);
            var dosage = await dosages.GetObject(c.DosageID);
            await schemes.LoadSchemes(dosage);
            var schems = dosage.SchemesInUse;
            var scheme = schems[0];
            char[] males = new[] { '1', '3', '5', '7', '9' };
            char[] females = new[] { '2', '4', '6', '8', '0' };
            string sex;
            if (males.Contains(person.DbRecord.IDCode[0]))
            {
                sex = "härra";
            }
            else
            {
                sex = "preili/proua";
            }

            string link;
            if (medicine.DbRecord.Spc.Contains("http"))
            {
                link = medicine.DbRecord.Spc;
            }
            else
            {
                link = "http://ravimiregister.ravimiamet.ee/Data/SPC/" + medicine.DbRecord.Spc;
            }
            string header = "Tervist lp " + sex + " " + person.DbRecord.LastName + "@" + "@";
            string suggestion = "Siin on teile kirjutatud soovitus Dr. Mardna poolt kuupäeval: " + c.ValidFrom +
                                "@" + "Isikukood : " + person.DbRecord.IDCode +
                                "@" + "Eesnimi : " + person.DbRecord.FirstName +
                                "@" + "Perekonnanimi : " + person.DbRecord.LastName +
                                "@" + "Ravimi nimi : " + medicine.DbRecord.Name +
                                "@" + "Ravimi manustamise viis : " + medicine.DbRecord.FormOfInjection +
                                "@" + "Ravimi tugevus : " + medicine.DbRecord.Strength +
                                "@" + "@" + "------ANNUSTAMINE------" +
                                "@" + "Ravimi manustamise tüüp : " + dosage.DbRecord.TypeOfTreatment +
                                "@" + "Ravikuuri pikkus : " + scheme.DbRecord.Length +
                                "@" + "Ravimit manustada ühe korraga : " + scheme.DbRecord.Amount +
                                "@" + "Ravimit manustada kordi päevas : " + scheme.DbRecord.Times +
                                "@" + "Eelistatud manustamise aeg : " + scheme.DbRecord.TimeOfDay +
                                "@" + "Lisainfot ravimi kohta leiad: " + link;
            string finalMessage = header + suggestion;
            finalMessage = finalMessage.Replace("@", System.Environment.NewLine);
            if(informationPreference==GetMedicineInfo.Email)
            {
                if(person.DbRecord.Email!= null && person.DbRecord.Email.Contains('@'))
                {
                    SendEmail(finalMessage, person);
                }
            }
            else if(informationPreference==GetMedicineInfo.SMS)
            {
                if(person.DbRecord.PhoneNumber != null)
                {
                    //sendSms(finalmessage, person);
                }
            }
            return RedirectToAction("PatientInfo", PersonViewModelFactory.Create(person));
        }
        public async void SendEmail(string finalMessage, PersonObject person)
        {
            EmailSender.Send(person.DbRecord.Email, finalMessage);
            
        }

        public async Task SetPropertiesMedicine(string personIdCode)
        {

            medicines.PageSize = 1000000;
            var l = await medicines.GetObjectsList();
            ViewBag.Medicines = l.Select(x => new SelectListItem
            {
                Value = x.DbRecord.ID,
                Text = x.DbRecord.Name + ", " + x.DbRecord.FormOfInjection + ", " + x.DbRecord.Strength
            }).ToList();
            var perObj = await persons.GetPersonByIDCode(personIdCode);
            ViewBag.PatientName = perObj.DbRecord.FirstName + " " + perObj.DbRecord.LastName;
        }

        public async Task SetPropertiesPerson(string medicineId)
        {
            var l = await persons.GetObjectsList();
            ViewBag.Persons = l.Select(x => new SelectListItem
            {
                Value = x.DbRecord.ID,
                Text = x.DbRecord.IDCode + ", " + x.DbRecord.FirstName + " " + x.DbRecord.LastName
            }).ToList();
            var medicine = await medicines.GetObject(medicineId);
            ViewBag.MedicineName = medicine.DbRecord.Name;
        }

        public async Task<bool> CheckMedicineSuitability(string personId, string medicineId)
        {
            try
            {
                var personMed = await personMedicines.GetObject(medicineId, personId);
                if (personMed.DbRecord.Suitability == Suitability.Ei)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        public async Task<Dictionary<string, string>> FindConflict(string personId, string medicineId)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var personMed = await personMedicines.GetObject(medicineId, personId);
            var validFrom = personMed.DbRecord.ValidFrom;
            var medicine = await medicines.GetObject(medicineId);
            await medEffects.LoadEffects(medicine);
            string effectsInMed = "";
            effectsInMed += medicine.EffectsInMedicines[0].DbRecord.Name;
            if (medicine.EffectsInMedicines.Count > 1)
            {
                for (int i = 1; i < medicine.EffectsInMedicines.Count; i++)
                {
                    effectsInMed += ", " + medicine.EffectsInMedicines[i].DbRecord.Name;
                }
            }
            dict["MedicineName"] = medicine.DbRecord.Name;
            dict["Effects"] = effectsInMed;
            dict["DateAssigned"] = validFrom.ToString();
            return dict;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await manager.GetUserAsync(HttpContext.User);
        }
    }
}
