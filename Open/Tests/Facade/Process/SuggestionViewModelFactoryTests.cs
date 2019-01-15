using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Facade.Process;

namespace Open.Tests.Facade.Process
{
    [TestClass]
    public class SuggestionViewModelFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SuggestionViewModelFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void SetNullIfExtremumTest()
        {
            Assert.Inconclusive();
        }
    }
}