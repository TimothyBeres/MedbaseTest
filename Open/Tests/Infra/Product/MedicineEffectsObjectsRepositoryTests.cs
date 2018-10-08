using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Product;

namespace Open.Tests.Infra.Product
{
    public class MedicineEffectsObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineEffectsObjectsRepository);
        }

        [TestMethod]
        public void GetObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void AddObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void UpdateObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void DeleteObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void LoadCountriesTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void LoadCurrenciesTest() { Assert.Inconclusive(); }
    }
}