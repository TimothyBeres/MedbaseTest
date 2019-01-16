using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Product;

namespace Open.Tests.Infra.Product
{
    [TestClass]
    public class MedicineObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new MedicineObjectsRepository(null));
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

        [TestMethod]
        public void GetMedicineTest()
        {
            Assert.Inconclusive();
        }
    }
}