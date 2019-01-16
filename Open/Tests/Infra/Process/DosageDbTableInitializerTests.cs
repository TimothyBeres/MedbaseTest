using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Process;

namespace Open.Tests.Infra.Process
{
    [TestClass]
    public class DosageDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(DosageDbTableInitializer);
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