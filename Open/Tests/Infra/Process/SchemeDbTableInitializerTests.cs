using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Process;

namespace Open.Tests.Infra.Process
{
    [TestClass]
    public class SchemeDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SchemeDbTableInitializer);
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