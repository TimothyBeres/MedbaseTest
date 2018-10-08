using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Product;

namespace Open.Tests.Infra.Product
{
    [TestClass]
    public class MedicinesDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicinesDbTableInitializer);
        }

        [TestMethod]
        public void CanInitializeTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}