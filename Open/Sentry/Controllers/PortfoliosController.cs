using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Product;
using Open.Facade.Product;
using Sentry1.Models;

namespace Sentry1.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly IPortfolioObjectsRepository portfolios;
        private readonly IMedicineObjectsRepository medicines;
        private readonly ICategoryObjectsRepository categories;
        private readonly ICategoryMedicineObjectsRepository categoryMedicines;
        private readonly UserManager<ApplicationUser> users;
        public const string properties = "ID, CategoryName, UserID, ValidFrom, ValidTo";


        public PortfoliosController(IPortfolioObjectsRepository p, UserManager<ApplicationUser> u, IMedicineObjectsRepository m, ICategoryObjectsRepository c, ICategoryMedicineObjectsRepository cm)
        {
            portfolios = p;
            users = u;
            medicines = m;
            categories = c;
            categoryMedicines = cm;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUser();
            var l = await portfolios.GetMedicines(user.Id);
            var catObjs = await categories.GetCategories(user.Id);
            List<CategoryViewModel> categoryViews = new List<CategoryViewModel>();
            foreach (var c in catObjs)
            {
                await categoryMedicines.LoadMedicines(c);
                categoryViews.Add(CategoryViewModelFactory.Create(c));

            }

            ViewBag.Categories = categoryViews;
            return View(PortfolioViewModelFactory.Create(user.Id, l));
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            return await users.GetUserAsync(HttpContext.User);
        }
        public async Task<IActionResult> AddMedicineToPortfolio(string medicineId, string categoryId)
        {
            var user = await GetCurrentUser();
            var medicine = await medicines.GetObject(medicineId);
            var category = await categories.GetObject(categoryId);
            await portfolios.AddObject(PortfolioObjectFactory.Create(medicine, user.Id, DateTime.Now));
            await categoryMedicines.AddObject(CategoryMedicineObjectFactory.Create(category, medicine));
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveMedicineFromPortfolio(string medicineId, string categoryId)
        {
            var user = await GetCurrentUser();

            var m = await medicines.GetObject(medicineId);
            var po = await portfolios.GetObject(m.DbRecord.ID, user.Id);
            await portfolios.DeleteObject(po);

            var cm = await categoryMedicines.GetObject(categoryId, m.DbRecord.ID);
            await categoryMedicines.DeleteObject(cm);
            
            return RedirectToAction("Index");
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory([Bind(properties)] CategoryViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var user = await GetCurrentUser();
            c.UserID = user.Id;
            var o = CategoryObjectFactory.Create(c.ID,c.UserID,c.CategoryName, c.ValidFrom, c.ValidTo);
            await categories.AddObject(o);
            return RedirectToAction("Index");
        }
    }
}