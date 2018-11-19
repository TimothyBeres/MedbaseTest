using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Person;

namespace Open.Tests.Infra.Person
{
    [TestClass]
    public class PersonsDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PersonsDbTableInitializer);
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