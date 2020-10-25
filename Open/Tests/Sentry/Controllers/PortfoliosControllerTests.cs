using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Open.Data.Person;
using Open.Data.Product;
using Open.Domain.Person;
using Open.Domain.Process;
using Open.Domain.Product;
using Open.Facade.Process;
using Open.Sentry1.Controllers;
using Sentry1.Controllers;
using Sentry1.Models;

namespace Open.Tests.Sentry.Controllers
{
    [TestClass]
    public class PortfoliosControllerTests
    {
        private ApplicationUser doctor;
        private ClaimsPrincipal user;
        private MedicineDbRecord medicineInPortfolio;
        private MedicineDbRecord medicineNotInPortfolio;
        private PortfoliosController controller;
        private Mock<IPortfolioObjectsRepository> portfolios = new Mock<IPortfolioObjectsRepository>();
        private Mock<IMedicineObjectsRepository> medicines = new Mock<IMedicineObjectsRepository>();
        private Mock<IEffectObjectsRepository> effects = new Mock<IEffectObjectsRepository>();
        private Mock<IMedicineEffectsObjectsRepository> medicineEffects = new Mock<IMedicineEffectsObjectsRepository>();
        private Mock<ICategoryObjectsRepository> categories = new Mock<ICategoryObjectsRepository>();
        private Mock<ICategoryMedicineObjectsRepository> categoryMedicines = new Mock<ICategoryMedicineObjectsRepository>();
        private Mock<UserManager<ApplicationUser>> userManager = new Mock<UserManager<ApplicationUser>>();
        public List<MedicineObject> medicinesInPortfolio;
        private CategoryDbRecord category;
        private ControllerContext context;
        private List<CategoryObject> categoryObjects;
        private List<PortfolioObject> portfolioObjects;
        private List<CategoryMedicineObject> categoryMedicineObjects;

        [TestInitialize]
        public void TestInitialize()
        {

            SetupUser();
            SetupMedicines();
            SetupCategory();
            categoryObjects = new List<CategoryObject>();
            portfolioObjects = new List<PortfolioObject>();
            categoryMedicineObjects = new List<CategoryMedicineObject>();
        }

        [TestMethod]
        public void AddMedicineToPortfolioTest()
        {
            userManager.Setup(repo => repo.GetUserAsync(user)).ReturnsAsync(doctor);
            controller = new PortfoliosController(portfolios.Object, userManager.Object, medicines.Object, 
                categories.Object,categoryMedicines.Object, medicineEffects.Object);

            controller.ControllerContext = context;

            medicines.Setup(repo => repo.GetObject(medicineInPortfolio.ID))
                .ReturnsAsync(new MedicineObject(medicineInPortfolio));
            categories.Setup(repo => repo.GetObject(category.ID))
                .ReturnsAsync(new CategoryObject(category));
            portfolios.Setup(repo => repo.AddObject(It.IsAny<PortfolioObject>())).Returns<PortfolioObject>(fg => AddPortfolio(fg));
            categoryMedicines.Setup(repo => repo.AddObject(It.IsAny<CategoryMedicineObject>()))
                .Returns<CategoryMedicineObject>(fg => AddCategoryMedicine(fg));

            var result = controller.AddMedicineToPortfolio(medicineNotInPortfolio.ID, category.ID);

            Assert.IsInstanceOfType(result.Result, typeof(RedirectToActionResult));
            Assert.AreEqual(1, portfolioObjects.Count);
            Assert.AreEqual(1, categoryMedicineObjects.Count);

        }

        [TestMethod]
        public void RemoveMedicineFromPortfolioTest()
        {
            userManager.Setup(repo => repo.GetUserAsync(user)).ReturnsAsync(doctor);
            controller = new PortfoliosController(portfolios.Object, userManager.Object, medicines.Object, categories.Object, 
                categoryMedicines.Object, medicineEffects.Object);
            
            controller.ControllerContext = context;
            
            medicines.Setup(repo => repo.GetObject(medicineInPortfolio.ID))
                .ReturnsAsync(new MedicineObject(medicineInPortfolio));
            portfolios.Setup(repo => repo.GetObject(medicineInPortfolio.ID, doctor.Id))
                .ReturnsAsync(new PortfolioObject(new PortfolioDbRecord()));
            categoryMedicines.Setup(repo => repo.GetObject(category.ID, medicineInPortfolio.ID))
                .ReturnsAsync(new CategoryMedicineObject(new CategoryMedicineDbRecord()));

            var result = controller.RemoveMedicineFromPortfolio(medicineInPortfolio.ID, category.ID);

            Assert.IsInstanceOfType(result.Result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void CreateCategoryTest()
        {

        }

        public async Task AddCategory(CategoryObject o)
        {
            categoryObjects.Add(o);
        }

        public async Task AddPortfolio(PortfolioObject o)
        {
            portfolioObjects.Add(o);
        }

        public async Task AddCategoryMedicine(CategoryMedicineObject o)
        {
            categoryMedicineObjects.Add(o);
        }
        public void SetupUser()
        {
            doctor = new ApplicationUser() { Id = "xyz" };
            var fakeIdentity = new GenericIdentity("doctor");
            user = new ClaimsPrincipal(fakeIdentity);
            context = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext
                {
                    User = user
                }
            };
            var store = new Mock<IUserStore<ApplicationUser>>();
            store.Setup(X => X.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new ApplicationUser() { Id = doctor.Id });

            userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
        }
        public void SetupMedicines()
        {
            medicineInPortfolio = new MedicineDbRecord();
            medicineInPortfolio.ID = "123";
            medicinesInPortfolio = new List<MedicineObject>(){new MedicineObject(medicineInPortfolio)};
            medicineNotInPortfolio = new MedicineDbRecord();
            medicineNotInPortfolio.ID = "987";

        }

        public void SetupCategory()
        {
            category = new CategoryDbRecord(){ID = "mnb"};
        }
    }
}
