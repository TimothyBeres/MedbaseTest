using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Person;

namespace Open.Tests.Facade.Person
{
    [TestClass]
    public class PersonInfoViewModelTests : ViewModelTests<PersonInfoViewModel,UniqueEntityViewModel >
    {
        protected override PersonInfoViewModel getRandomTestObject()
        {
            return GetRandom.Object<PersonInfoViewModel>();
        }
        [TestMethod]
        public void MedicineNameTest()
        {
            testReadWriteProperty(() => obj.MedicineName, x => obj.MedicineName = x);
        }
        [TestMethod]
        public void FormOfInjectionTest()
        {
            testReadWriteProperty(() => obj.FormOfInjection, x => obj.FormOfInjection = x);
        }
        [TestMethod]
        public void SuitabilityTest()
        {
            testReadWriteProperty(() => obj.Suitability, x => obj.Suitability = x);
        }
        [TestMethod]
        public void MedicineIDTest()
        {
            testReadWriteProperty(() => obj.MedicineID, x => obj.MedicineID = x);
        }
        [TestMethod]
        public void DosageIDTest()
        {
            testReadWriteProperty(() => obj.DosageID, x => obj.DosageID = x);
        }
        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
        }
        [TestMethod]
        public void EmptyHeaderTest()
        {
            testReadWriteProperty(() => obj.EmptyHeader, x => obj.EmptyHeader = x);
        }
    }
}
