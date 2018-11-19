using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Person;

namespace Open.Tests.Infra.Person
{
    [TestClass]
    public class PersonMedicineDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PersonMedicineDbTableInitializer);
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}