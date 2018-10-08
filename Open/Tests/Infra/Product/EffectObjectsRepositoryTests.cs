using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Product;

namespace Open.Tests.Infra.Product
{
    [TestClass]
    public class EffectObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EffectObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new EffectObjectsRepository(null));
        }

        [TestMethod]
        public void GetObjectsListTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void IsInitializedTest()
        {
            Assert.Inconclusive();
        }
    }
}