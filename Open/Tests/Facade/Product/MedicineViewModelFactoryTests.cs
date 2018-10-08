using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Product;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class MedicineViewModelFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineViewModelFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var o = GetRandom.Object<MedicineObject>();
            var v = MedicineViewModelFactory.Create(o);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.Name, o.DbRecord.Name);
            Assert.AreEqual(v.AtcCode, o.DbRecord.AtcCode);
            Assert.AreEqual(v.FormOfInjection, o.DbRecord.FormOfInjection);
            Assert.AreEqual(v.Strength, o.DbRecord.Strength);
            Assert.AreEqual(v.Manufacturer, o.DbRecord.Manufacturer);
            Assert.AreEqual(v.LegalStatus, o.DbRecord.LegalStatus);
            Assert.AreEqual(v.Reimbursement, o.DbRecord.Reimbursement);
            Assert.AreEqual(v.Spc, o.DbRecord.Spc);
            Assert.AreEqual(v.Pil, o.DbRecord.Pil);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
        }

        [TestMethod]
        public void CreateNullTest()
        {
            var v = MedicineViewModelFactory.Create(null);
            Assert.AreEqual(v.ID, Constants.Unspecified);
            Assert.AreEqual(v.Name, Constants.Unspecified);
            Assert.AreEqual(v.AtcCode, Constants.Unspecified);
            Assert.AreEqual(v.FormOfInjection, Constants.Unspecified);
            Assert.AreEqual(v.Strength, Constants.Unspecified);
            Assert.AreEqual(v.Manufacturer, Constants.Unspecified);
            Assert.AreEqual(v.LegalStatus, Constants.Unspecified);
            Assert.AreEqual(v.Reimbursement, false);
            Assert.AreEqual(v.Spc, Constants.Unspecified);
            Assert.AreEqual(v.Pil, Constants.Unspecified);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }

        [TestMethod]
        public void setNullIfExtremumTest()
        {
            var o = GetRandom.Object<MedicineObject>();
            o.DbRecord.ValidFrom = DateTime.MinValue;
            o.DbRecord.ValidTo = DateTime.MaxValue;
            var v = MedicineViewModelFactory.Create(o);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.Name, o.DbRecord.Name);
            Assert.AreEqual(v.AtcCode, o.DbRecord.AtcCode);
            Assert.AreEqual(v.FormOfInjection, o.DbRecord.FormOfInjection);
            Assert.AreEqual(v.Strength, o.DbRecord.Strength);
            Assert.AreEqual(v.Manufacturer, o.DbRecord.Manufacturer);
            Assert.AreEqual(v.LegalStatus, o.DbRecord.LegalStatus);
            Assert.AreEqual(v.Reimbursement, o.DbRecord.Reimbursement);
            Assert.AreEqual(v.Spc, o.DbRecord.Spc);
            Assert.AreEqual(v.Pil, o.DbRecord.Pil);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }
}