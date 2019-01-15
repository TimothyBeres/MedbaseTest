using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Process;

namespace Open.Tests.Infra.Process
{
    [TestClass]
    public class DosageObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(DosageObjectsRepository);
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
        public void GetAllDosagesTest()
        {
            Assert.Inconclusive();
        }
    }
}