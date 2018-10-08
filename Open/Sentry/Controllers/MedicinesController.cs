using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;
using Open.Facade.Product;

namespace Open.Sentry1.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly IMedicineObjectsRepository repository;
        private readonly IMedicineEffectsObjectsRepository medicineEffectsRepository;
        private readonly IEffectObjectsRepository effectsRepository;
        public const string properties = "ID, Name, AtcCode, FormOfInjection, Strength" +
                                         ", Manufacturer, LegalStatus, Reimbursement, Spc, Pil, ValidFrom, ValidTo";

        public MedicinesController(IMedicineObjectsRepository r,
            IMedicineEffectsObjectsRepository me, IEffectObjectsRepository e)
        {
            repository = r;
            medicineEffectsRepository = me;
            effectsRepository = e;
        }

        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortName"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SortAtcCode"] = sortOrder == "atc_code" ? "atc_code_desc" : "atc_code";
            ViewData["SortFormOfInjection"] = sortOrder == "form_of_injection" ? "form_of_injection_desc" : "form_of_injection";
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(properties)] MedicineViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = MedicineObjectFactory.Create(c.ID, c.Name, c.AtcCode, c.FormOfInjection, c.Strength, c.Manufacturer,
                c.LegalStatus, c.Reimbursement, c.Spc, c.Pil, c.ValidFrom, c.ValidTo);
            await repository.AddObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            effectsRepository.SearchString = searchString;
            effectsRepository.PageIndex = page ?? 1;
            var effects = new EffectViewModelsList(null);
            if (!string.IsNullOrWhiteSpace(searchString))
                effects = new EffectViewModelsList(await effectsRepository.GetObjectsList());
            var a = await repository.GetObject(id);
            await medicineEffectsRepository.LoadEffects(a);
            var med = MedicineViewModelFactory.Create(a);
            foreach (var effect in med.EffectsInMedicine)
            {
                effects.RemoveAll(x => x.Name == effect.Name);
            }

            ViewBag.Products = effects;
            return View(med);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(properties)] MedicineViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            var o = await repository.GetObject(c.ID);
            o.DbRecord.Name = c.Name;
            o.DbRecord.AtcCode = c.AtcCode;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await repository.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var c = await repository.GetObject(id);
            await medicineEffectsRepository.LoadEffects(c);
            return View(MedicineViewModelFactory.Create(c));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var c = await repository.GetObject(id);
            return View(MedicineViewModelFactory.Create(c));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var c = await repository.GetObject(id);
            await repository.DeleteObject(c);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddEffect(string effect, string medicine)
        {
            var r = new MedicineEffectsDbRecord()
            {
                EffectID = effect,
                MedicineID = medicine
            };
            await medicineEffectsRepository.AddObject(new MedicineEffectsObject(r));
            return RedirectToAction("Edit", new { id = effect });
        }

        public async Task<IActionResult> RemoveEffect(string effect, string medicine)
        {
            var o = await medicineEffectsRepository.GetObject(effect, medicine);
            await medicineEffectsRepository.DeleteObject(o);
            return RedirectToAction("Edit", new { id = effect });
        }
    }
}