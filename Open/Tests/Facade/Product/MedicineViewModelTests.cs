using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class MedicineViewModelTests : ViewModelTests<MedicineViewModel, UniqueEntityViewModel>
    {
        protected override MedicineViewModel getRandomTestObject()
        {
            return GetRandom.Object<MedicineViewModel>();
        }

        [TestMethod]
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void AtcCodeTest()
        {
            testReadWriteProperty(() => obj.AtcCode, x => obj.AtcCode = x);
        }

        [TestMethod]
        public void FormOfInjectionTest()
        {
            testReadWriteProperty(() => obj.FormOfInjection, x => obj.FormOfInjection = x);
        }

        [TestMethod]
        public void StrengthTest()
        {
            testReadWriteProperty(() => obj.Strength, x => obj.Strength = x);
        }

        [TestMethod]
        public void ManufacturerTest()
        {
            testReadWriteProperty(() => obj.Manufacturer, x => obj.Manufacturer = x);
        }

        [TestMethod]
        public void LegalStatusTest()
        {
            testReadWriteProperty(() => obj.LegalStatus, x => obj.LegalStatus = x);
        }

        [TestMethod]
        public void ReimbursementTest()
        {
            testReadWriteProperty(() => obj.Reimbursement, x => obj.Reimbursement = x);
        }

        [TestMethod]
        public void SpcTest()
        {
            testReadWriteProperty(() => obj.Spc, x => obj.Spc = x);
        }

        [TestMethod]
        public void PilTest()
        {
            testReadWriteProperty(() => obj.Pil, x => obj.Pil = x);
        }

        [TestMethod]
        public void EffectsInMedicineTest()
        {
            Assert.IsInstanceOfType(obj.EffectsInMedicine, typeof(List<EffectViewModel>));
            var name = GetMember.Name<MedicineViewModel>(x => x.EffectsInMedicine);
            Assert.IsTrue(IsReadOnly.Property<MedicineViewModel>(name));
        }
    }
}