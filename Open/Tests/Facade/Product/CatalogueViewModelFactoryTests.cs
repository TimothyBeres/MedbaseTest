using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Product;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    /*[TestClass]
    public class CatalogueViewModelFactoryTests : BaseTests
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
            Assert.AreEqual(v.CatalogueName, o.DbRecord.CatalogueName);
            Assert.AreEqual(v.Description, o.DbRecord.Description);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
        }

        [TestMethod]
        public void CreateNullTest()
        {
            var v = MedicineViewModelFactory.Create(null);
            Assert.AreEqual(v.CatalogueName, Constants.Unspecified);
            Assert.AreEqual(v.Description, Constants.Unspecified);
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
            Assert.AreEqual(v.CatalogueName, o.DbRecord.CatalogueName);
            Assert.AreEqual(v.Description, o.DbRecord.Description);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }*/
}