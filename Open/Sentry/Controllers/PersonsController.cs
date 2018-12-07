using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Person;
using Open.Facade.Person;

namespace Sentry1.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonObjectsRepository persons;
        public const string properties = "ID, IDCode, FirstName, LastName, ValidFrom, ValidTo";
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
            var o = PersonObjectFactory.Create(c.ID, c.IDCode, c.FirstName, c.LastName, c.ValidFrom, c.ValidTo);
            await persons.AddObject(o);
            return RedirectToAction("PatientInfo", "Suggestions", c);
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