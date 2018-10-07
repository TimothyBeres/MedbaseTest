using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;

namespace Open.Tests.Infra
{
    [TestClass]
    public class DbTablesInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(DbTablesInitializer);
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}