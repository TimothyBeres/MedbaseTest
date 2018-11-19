using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Person;
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
        public void MedicinesInUseTest()
        {
            Assert.IsInstanceOfType(obj.MedicinesInUse, typeof(List<MedicineViewModel>));
        }
    }
}