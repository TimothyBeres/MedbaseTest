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
        private readonly UserManager<ApplicationUser> users;

        public PortfoliosController(IPortfolioObjectsRepository p, UserManager<ApplicationUser> u, IMedicineObjectsRepository m)
        {
            portfolios = p;
            users = u;
            medicines = m;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUser();
            var l = await portfolios.GetMedicines(user.Id);
            return View(PortfolioViewModelFactory.Create(user.Id, l));
        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await users.GetUserAsync(HttpContext.User);
        }
        public async Task<IActionResult> AddMedicineToPortfolio(string id)
        {
            var user = await GetCurrentUser();

            var m = await medicines.GetObject(id);
            await portfolios.AddObject(PortfolioObjectFactory.Create(m, user.Id, DateTime.Now));
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveMedicineFromPortfolio(string medicineId)
        {
            var user = await GetCurrentUser();

            var m = await medicines.GetObject(medicineId);
            var po = await portfolios.GetObject(m.DbRecord.ID, user.Id);
            await portfolios.DeleteObject(po);
            return RedirectToAction("Index");
        }
    }
}