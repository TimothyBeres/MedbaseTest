using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    /*[TestClass]
    public class CatalogueObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineObjectFactory);
        }

        private void testVariables(CatalogueDbRecord o, string id, string name, string description, DateTime vFrom,
            DateTime vTo)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(name, o.CatalogueName);
            Assert.AreEqual(description, o.Description);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<CatalogueDbRecord>();
            var o = MedicineObjectFactory.Create(r.ID, r.CatalogueName, r.Description, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(MedicineObject));
            testVariables(o.DbRecord, r.ID, r.CatalogueName, r.Description, r.ValidFrom, r.ValidTo);
        }
    }*/
}