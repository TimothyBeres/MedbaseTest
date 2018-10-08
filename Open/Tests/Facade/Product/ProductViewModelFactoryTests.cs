using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Product;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    /*[TestClass]
    public class ProductViewModelFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EffectViewModelFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var o = GetRandom.Object<EffectObject>();
            var v = EffectViewModelFactory.Create(o);
            Assert.AreEqual(v.ProductName, o.DbRecord.ProductName);
            Assert.AreEqual(v.ProductType, o.DbRecord.ProductType);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
        }

        [TestMethod]
        public void CreateNullTest()
        {
            var v = EffectViewModelFactory.Create(null);
            Assert.AreEqual(v.ProductName, Constants.Unspecified);
            Assert.AreEqual(v.ProductType, Constants.Unspecified);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }

        [TestMethod]
        public void setNullIfExtremumTest()
        {
            var o = GetRandom.Object<EffectObject>();
            o.DbRecord.ValidFrom = DateTime.MinValue;
            o.DbRecord.ValidTo = DateTime.MaxValue;
            var v = EffectViewModelFactory.Create(o);
            Assert.AreEqual(v.ProductName, o.DbRecord.ProductName);
            Assert.AreEqual(v.ProductType, o.DbRecord.ProductType);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }*/
}