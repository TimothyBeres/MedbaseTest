using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Product;

namespace Open.Tests.Data.Product
{
    [TestClass]
    public class ProductDbRecordTests : ObjectTests<EffectDbRecord>
    {
        protected override EffectDbRecord getRandomTestObject()
        {
            return GetRandom.Object<EffectDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(EffectDbRecord).BaseType);
        }

        [TestMethod]
        public void ProductTypeTest()
        {
            testReadWriteProperty(() => obj.ProductType, x => obj.ProductType = x);
        }

        [TestMethod]
        public void ProductNameTest()
        {
            testReadWriteProperty(() => obj.ProductName, x => obj.ProductName = x);
        }
    }
}