using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Product;

namespace Open.Tests.Infra.Product
{
    [TestClass]
    public class ProductCataloguesDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineEffectsDbTableInitializer);
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}