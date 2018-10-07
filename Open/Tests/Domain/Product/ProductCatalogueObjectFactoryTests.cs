using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class ProductCatalogueObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineEffectsObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<MedicineEffectsDbRecord>();
            var product = new EffectObject(r.Product);
            var catalogue = new MedicineObject(r.Catalogue);

            var o = MedicineEffectsObjectFactory.Create(product, catalogue, r.ValidFrom,
                r.ValidTo);

            Assert.AreEqual(o.DbRecord.ValidFrom, r.ValidFrom);
            Assert.AreEqual(o.DbRecord.ValidTo, r.ValidTo);
            Assert.AreEqual(o.Product.DbRecord, r.Product);
            Assert.AreEqual(o.Catalogue.DbRecord, r.Catalogue);
            Assert.AreEqual(o.DbRecord.ProductID, r.Product.ID);
            Assert.AreEqual(o.DbRecord.CatalogueID, r.Catalogue.ID);
            Assert.AreEqual(o.DbRecord.Product, r.Product);
            Assert.AreEqual(o.DbRecord.Catalogue, r.Catalogue);
        }

        [TestMethod]
        public void CreateWithNullArgumentsTest()
        {
            var o = MedicineEffectsObjectFactory.Create(null, null);

            Assert.AreEqual(o.DbRecord.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(o.DbRecord.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(o.Product.DbRecord, o.DbRecord.Product);
            Assert.AreEqual(o.Catalogue.DbRecord, o.DbRecord.Catalogue);
            Assert.AreEqual(o.DbRecord.ProductID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.CatalogueID, Constants.Unspecified);
        }
    }
}