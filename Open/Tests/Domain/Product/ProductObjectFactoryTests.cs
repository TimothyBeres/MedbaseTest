using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class ProductObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EffectObjectFactory);
        }

        private void testVariables(EffectDbRecord o, string id, string name, string type, DateTime vFrom,
            DateTime vTo)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(name, o.ProductName);
            Assert.AreEqual(type, o.ProductType);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<EffectDbRecord>();
            var o = EffectObjectFactory.Create(r.ID, r.ProductName, r.ProductType, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(EffectObject));
            testVariables(o.DbRecord, r.ID, r.ProductName, r.ProductType, r.ValidFrom, r.ValidTo);
        }
    }
}