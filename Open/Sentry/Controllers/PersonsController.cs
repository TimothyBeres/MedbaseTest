using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Data.Person;
using Open.Domain.Person;
using Open.Facade.Person;

namespace Sentry1.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonObjectsRepository persons;
        public const string properties = "ID, IDCode, FirstName, LastName, Address, Email, PhoneNumber, GetMedicineInfo, ValidFrom, ValidTo";
        public PersonsController(IPersonObjectsRepository p)
        {
            persons = p;
        }

        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            persons.SearchString = searchString;
            persons.PageIndex = page ?? 1;
            var l = await persons.GetObjectsList();
            return View(new PersonViewModelsList(l));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(properties)] PersonViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            bool isUnique = await IsUnique(c.IDCode);
            if (!isUnique)
            {
                ViewBag.Message = "Sellise id-koodiga inimene on juba registreeritud!";
                return View();
            }
            c.ID = Guid.NewGuid().ToString();
            var o = PersonObjectFactory.Create(c.ID, c.IDCode, c.FirstName, c.LastName, c.Address, c.Email, c.PhoneNumber, c.GetMedicineInfo, c.ValidFrom, c.ValidTo);
            await persons.AddObject(o);
            return RedirectToAction("PatientInfo", "Suggestions", c);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var c = await persons.GetObject(id);
            return View(PersonViewModelFactory.Create(c));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] PersonViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await persons.GetObject(c.ID);
            o.DbRecord.FirstName = c.FirstName;
            o.DbRecord.LastName = c.LastName;
            o.DbRecord.IDCode = c.IDCode;
            o.DbRecord.Address = c.Address;
            o.DbRecord.Email = c.Email;
            o.DbRecord.PhoneNumber = c.PhoneNumber;
            o.DbRecord.GetMedicineInfo = c.GetMedicineInfo;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await persons.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var c = await persons.GetObject(id);
            return View(PersonViewModelFactory.Create(c));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var c = await persons.GetObject(id);
            await persons.DeleteObject(c);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var c = await persons.GetObject(id);
            //await medicineEffectsRepository.LoadEffects(c);
            return View(PersonViewModelFactory.Create(c));
        }



        private async Task<bool> IsUnique(string idCode)
        {
            try
            {
                var person = await persons.GetPersonByIDCode(idCode);
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
    }
}