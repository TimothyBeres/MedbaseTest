using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class ProductCatalogueObjectTests : ObjectTests<MedicineEffectsObject>
    {
        protected override MedicineEffectsObject getRandomTestObject()
        {
            return GetRandom.Object<MedicineEffectsObject>();
        }

        [TestMethod]
        public void ProductTest()
        {
            Assert.AreEqual(obj.Product.DbRecord, obj.DbRecord.Product);
        }

        [TestMethod]
        public void CatalogueTest()
        {
            Assert.AreEqual(obj.Catalogue.DbRecord, obj.DbRecord.Catalogue);
        }

        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new MedicineEffectsObject(null);
            Assert.AreEqual(obj.Product.DbRecord, obj.DbRecord.Product);
            Assert.AreEqual(obj.Product.DbRecord, obj.DbRecord.Product);
        }
    }
}