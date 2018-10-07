using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;

namespace Open.Tests.Data.Product
{
    [TestClass]
    public class CatalogueDbRecordTests : ObjectTests<CatalogueDbRecord>
    {
        protected override CatalogueDbRecord getRandomTestObject()
        {
            return GetRandom.Object<CatalogueDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(CatalogueDbRecord).BaseType);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
        }

        [TestMethod]
        public void CatalogueNameTest()
        {
            testReadWriteProperty(() => obj.CatalogueName, x => obj.CatalogueName = x);
        }
    }
}