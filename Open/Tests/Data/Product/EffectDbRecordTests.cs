using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Product;

namespace Open.Tests.Data.Product
{
    [TestClass]
    public class EffectDbRecordTests : ObjectTests<EffectDbRecord>
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
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }
    }
}