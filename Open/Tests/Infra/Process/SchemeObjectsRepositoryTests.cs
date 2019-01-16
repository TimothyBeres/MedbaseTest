using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Process;

namespace Open.Tests.Infra.Process
{
    [TestClass]
    public class SchemeObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SchemeObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new SchemeObjectsRepository(null));
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
        public void LoadSchemesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetSchemesByDosageIDTest()
        {
            Assert.Inconclusive();
        }
    }
}