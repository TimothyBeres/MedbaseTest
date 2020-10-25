using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Open.Core;
using Open.Data.Person;
using Open.Data.Product;
using Open.Domain.Person;
using Open.Domain.Process;
using Open.Domain.Product;
using Open.Facade.Process;
using Open.Infra.Product;
using Open.Sentry1.Controllers;
using Open.Tests.Aids;
using Sentry1.Models;

namespace Open.Tests.Sentry.Controllers
{
    [TestClass]
    public class SuggestionsControllerTests
    {
        private ApplicationUser doctor;
        private PersonDbRecord patient;
        private MedicineDbRecord medicine;
        private SuggestionsController controller;
        private Mock<IPortfolioObjectsRepository> portfolios = new Mock<IPortfolioObjectsRepository>();
        private Mock<IPersonObjectsRepository> persons = new Mock<IPersonObjectsRepository>();
        private Mock<IPersonMedicineObjectsRepository> personMedicines = new Mock<IPersonMedicineObjectsRepository>();
        private Mock<IMedicineObjectsRepository> medicines = new Mock<IMedicineObjectsRepository>();
        private Mock<IDosageObjectsRepository> dosages = new Mock<IDosageObjectsRepository>();
        private Mock<ISchemeObjectsRepository> schemes = new Mock<ISchemeObjectsRepository>();
        private Mock<IEffectObjectsRepository> effects = new Mock<IEffectObjectsRepository>();
        private Mock<IMedicineEffectsObjectsRepository> medicineEffects = new Mock<IMedicineEffectsObjectsRepository>();
        private UserManager<ApplicationUser> userManager;
        private SuggestionViewModel suggestionViewModel;
        public List<PersonMedicineObject> personMedObjects;
        public List<MedicineObject> medicineObjects;

        [TestInitialize]
        public void TestInitialize()
        {
            SetupUsers();            
            SetupViewModels();
            personMedObjects = new List<PersonMedicineObject>();
            medicineObjects = new List<MedicineObject>();
            SetupMedicines();

        }
        [TestMethod]
        public void DosageSchemeTestSuitable()
        {
            //Test that a new suggestion is added to the user. PS! E-mail sending can not be currently tested functionally.
            // Arrange
            controller = SetupController();
            persons.Setup(repo => repo.GetPersonByIDCode(patient.IDCode)).ReturnsAsync(new PersonObject(patient));
            personMedicines.Setup(repo => repo.GetObject("123", "abc"))
                .ReturnsAsync(new PersonMedicineObject(new PersonMedicineDbRecord()) {Medicine = { }, Person = { }});
            personMedicines.Setup(repo => repo.AddObject(It.IsAny<PersonMedicineObject>())).Returns<PersonMedicineObject>(fg => AddPerMed(fg));
            medicines.Setup(repo => repo.GetObject("123")).ReturnsAsync(new MedicineObject(medicine));
            
            // Act
            var x = medicines.Object.GetObjectsList();
            var result = controller.DosageScheme(suggestionViewModel, "123", "");
            var resultPrior = controller.DosageScheme(suggestionViewModel, "123", "prior");


            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(RedirectToActionResult));
            Assert.AreEqual(2, personMedObjects.Count);
            Assert.AreEqual(personMedObjects[0].Person.DbRecord.IDCode, patient.IDCode);
            Assert.AreEqual(personMedObjects[0].Medicine.DbRecord.ID, medicine.ID);


        }
        [TestMethod]
        public void DosageSchemeTestNotSuitable()
        {
            //Test that a new suggestion is added to the user. PS! E-mail sending can not be currently tested functionally.
            // Arrange
            controller = SetupController();
            medicines.Setup(repo => repo.GetObjectsList())
                .ReturnsAsync(new MedicineObjectsList(new List<MedicineDbRecord>(), new RepositoryPage(0)));
            persons.Setup(repo => repo.GetPersonByIDCode(patient.IDCode)).ReturnsAsync(new PersonObject(patient));
            personMedicines.Setup(repo => repo.GetObject("123", "abc"))
                .ReturnsAsync(new PersonMedicineObject(new PersonMedicineDbRecord(){Suitability = Suitability.Jah}) { Medicine = { }, Person = { } });
            personMedicines.Setup(repo => repo.AddObject(It.IsAny<PersonMedicineObject>())).Returns<PersonMedicineObject>(fg => AddPerMed(fg));
            medicines.Setup(repo => repo.GetObject("123")).ReturnsAsync(new MedicineObject(medicine));

            // Act
            var x = medicines.Object.GetObjectsList();
            var result = controller.DosageScheme(suggestionViewModel, "123", "");

            //Change suitability to "no", meaning user will not get a suggestion unless "prior" is passed into the controller.
            personMedicines.Setup(repo => repo.GetObject("123", "abc"))
                .ReturnsAsync(new PersonMedicineObject(new PersonMedicineDbRecord() { Suitability = Suitability.Ei }) { Medicine = { }, Person = { } });

            var resultPrior = controller.DosageScheme(suggestionViewModel, "123", "prior");
            var resultPriorFail = controller.DosageScheme(suggestionViewModel, "123", "");

            //Suitability stays the same, "no", but medicine that is suggested, has already been suggested to the user before.
            //Triggers additional blocks in code.
            personMedicines.Setup(repo => repo.GetObject("123", "abc"))
                .ReturnsAsync(new PersonMedicineObject(new PersonMedicineDbRecord() {Suitability = Suitability.Ei, Medicine = medicine}));
            var resultsFinalPrior = controller.DosageScheme(suggestionViewModel, "123", "prior");
            var resultsFinal = controller.DosageScheme(suggestionViewModel, "123", "");

            // Assert
            //Check that only the correct amount of suggestions were added to the suggestions database.
            Assert.IsInstanceOfType(result.Result, typeof(RedirectToActionResult));
            Assert.AreEqual(3, personMedObjects.Count);
            Assert.AreEqual(personMedObjects[0].Person.DbRecord.IDCode, patient.IDCode);
            Assert.AreEqual(personMedObjects[0].Medicine.DbRecord.ID, medicine.ID);


        }

        public async Task AddPerMed(PersonMedicineObject obj)
        {
            personMedObjects.Add(obj);
        }
        public void SetupMedicines()
        {
            medicine = new MedicineDbRecord();
            medicine.ID= "123";
            medicineObjects.Add(new MedicineObject(medicine));
        }

        public SuggestionsController SetupController()
        {
            return new SuggestionsController(persons.Object, personMedicines.Object, medicines.Object, 
                dosages.Object, schemes.Object, effects.Object, medicineEffects.Object, portfolios.Object, userManager);
        }

        public void SetupViewModels()
        {
            suggestionViewModel = SuggestionViewModelFactory.Create(patient.ID);
        }

        public void SetupUsers()
        {
            doctor = new ApplicationUser(){Id = "xyz"};
            patient = new PersonDbRecord(){ID = "abc", IDCode = "abc"};
            persons.Object.AddObject(new PersonObject(patient));
        }
    }
}
