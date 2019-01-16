using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Domain.Money;
using Open.Facade.Location;

namespace Open.Sentry1.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryObjectsRepository repository;
        private readonly ICountryCurrencyObjectsRepository currencies;
        public const string properties = "Alpha3Code, Alpha2Code, Name, ValidFrom, ValidTo";

        public CountriesController(ICountryObjectsRepository r, ICountryCurrencyObjectsRepository c)
        {
            repository = r;
            currencies = c;
        }
        [Authorize]
        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SortAlpha3"] = sortOrder == "alpha3" ? "alpha3_desc" : "alpha3";
            ViewData["SortAlpha2"] = sortOrder == "alpha2" ? "alpha2_desc" : "alpha2";
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
            return View(new CountryViewModelsList(l));
        }

        private Func<CountryDbRecord, object> getSortFunction(string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("alpha3")) return x => x.ID;
            if (sortOrder.StartsWith("alpha2")) return x => x.Code;
            return x => x.Name;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(properties)] CountryViewModel c)
        {
            await validateId(c.Alpha3Code, ModelState);
            if (!ModelState.IsValid) return View(c);
            var o = CountryObjectFactory.Create(c.Alpha3Code, c.Name, c.Alpha2Code, c.ValidFrom, c.ValidTo);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var c = await repository.GetObject(id);
            return View(CountryViewModelFactory.Create(c));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] CountryViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.Alpha3Code);
            o.DbRecord.Name = c.Name;
            o.DbRecord.Code = c.Alpha2Code;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var c = await repository.GetObject(id);
            await currencies.LoadCurrencies(c);
            return View(CountryViewModelFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var c = await repository.GetObject(id);
            return View(CountryViewModelFactory.Create(c));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var c = await repository.GetObject(id);
            await repository.DeleteObject(c);
            return RedirectToAction("Index");
        }

        private async Task validateId(string id, ModelStateDictionary d)
        {
            if (await isIdInUse(id))
                d.AddModelError(string.Empty, idIsInUseMessage(id));
        }

        private async Task<bool> isIdInUse(string id)
        {
            return (await repository.GetObject(id))?.DbRecord?.ID == id;
        }
        public ActionResult ModalPopUp()
        {
            return View();
        }
        private static string idIsInUseMessage(string id)
        {
            var name = GetMember.DisplayName<CountryViewModel>(c => c.Alpha3Code);
            return string.Format(Messages.ValueIsAlreadyInUse, id, name);
        }
    }
}