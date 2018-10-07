using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;

namespace Open.Tests.Data.Product
{
    [TestClass]
    public class ProductCatalogueDbRecordTests : ObjectTests<MedicineEffectsDbRecord>
    {
        protected override MedicineEffectsDbRecord getRandomTestObject()
        {
            return GetRandom.Object<MedicineEffectsDbRecord>();
        }

        [TestMethod]
        public void CatalogueIDTest()
        {
            testReadWriteProperty(() => obj.CatalogueID, x => obj.CatalogueID = x);
            testNullEmptyAndWhitespaceCases(() => obj.CatalogueID, x => obj.CatalogueID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void ProductIDTest()
        {
            testReadWriteProperty(() => obj.ProductID, x => obj.ProductID = x);
            testNullEmptyAndWhitespaceCases(() => obj.ProductID, x => obj.ProductID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void CatalogueTest()
        {
            testReadWriteProperty(() => obj.Catalogue, x => obj.Catalogue = x);
            obj.Catalogue = null;
            Assert.IsNull(obj.Catalogue);
        }

        [TestMethod]
        public void ProductTest()
        {
            testReadWriteProperty(() => obj.Product, x => obj.Product = x);
            obj.Product = null;
            Assert.IsNull(obj.Product);
        }
    }
}