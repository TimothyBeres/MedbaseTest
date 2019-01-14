using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Person;
using Open.Facade.Process;
using Open.Facade.Product;

namespace Open.Tests.Facade.Person
{
    [TestClass]
    public class PersonViewModelTests : ViewModelTests<PersonViewModel, UniqueEntityViewModel>
    {
        protected override PersonViewModel getRandomTestObject()
        {
            return GetRandom.Object<PersonViewModel>();
        }

        [TestMethod]
        public void IDCodeTest()
        {
            testReadWriteProperty(() => obj.IDCode, x => obj.IDCode = x);
        }

        [TestMethod]
        public void FirstNameTest()
        {
            testReadWriteProperty(() => obj.FirstName, x => obj.FirstName = x);
        }

        [TestMethod]
        public void LastNameTest()
        {
            testReadWriteProperty(() => obj.LastName, x => obj.LastName = x);
        }
        [TestMethod]
        public void AddressTest()
        {
            testReadWriteProperty(() => obj.Address, x => obj.Address = x);
        }
        [TestMethod]
        public void EmailTest()
        {
            testReadWriteProperty(() => obj.Email, x => obj.Email = x);
        }
        [TestMethod]
        public void PhoneNumberTest()
        {
            testReadWriteProperty(() => obj.PhoneNumber, x => obj.PhoneNumber = x);
        }
        [TestMethod]
        public void GetMedicineInfoTest()
        {
            testReadWriteProperty(() => obj.GetMedicineInfo, x => obj.GetMedicineInfo = x);
        }
        [TestMethod]
        public void ValidFromTest()
        {
            testReadWriteProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }
        [TestMethod]
        public void EmptyHeaderTest()
        {
            testReadWriteProperty(() => obj.EmptyHeader, x => obj.EmptyHeader = x);
        }
        [TestMethod]
        public void SuggestionsMadeTest()
        {
            Assert.IsInstanceOfType(obj.SuggestionsMade, typeof(List<PersonInfoViewModel>));
        }
        [TestMethod]
        public void MedicinesInUseTest()
        {
            Assert.IsInstanceOfType(obj.MedicinesInUse, typeof(List<MedicineViewModel>));
        }
    }
}