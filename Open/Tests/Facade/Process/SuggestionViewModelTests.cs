using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Process;
using Open.Facade.Product;

namespace Open.Tests.Facade.Process
{
    [TestClass]
    public class SuggestionViewModelTests : ViewModelTests<SuggestionViewModel, UniqueEntityViewModel>
    {
        protected override SuggestionViewModel getRandomTestObject()
        {
            return GetRandom.Object<SuggestionViewModel>();
        }

        [TestMethod]
        public void MedicineIDTest()
        {
            testReadWriteProperty(() => obj.MedicineID, x => obj.MedicineID = x);
        }

        [TestMethod]
        public void TypeOfTreatmentTest()
        {
            testReadWriteProperty(() => obj.TypeOfTreatment, x => obj.TypeOfTreatment = x);
        }

        [TestMethod]
        public void LengthTest()
        {
            testReadWriteProperty(() => obj.Length, x => obj.Length = x);
        }

        [TestMethod]
        public void AmountTest()
        {
            testReadWriteProperty(() => obj.Amount, x => obj.Amount = x);
        }

        [TestMethod]
        public void TimesTest()
        {
            testReadWriteProperty(() => obj.Times, x => obj.Times = x);
        }

        [TestMethod]
        public void TimeOfDayTest()
        {
            testReadWriteProperty(() => obj.TimeOfDay, x => obj.TimeOfDay = x);
        }

        [TestMethod]
        public void UsedMedicineTest()
        {
            testReadWriteProperty(() => obj.UsedMedicine, x => obj.UsedMedicine = x);
        }
    }
}