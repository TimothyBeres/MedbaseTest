using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Person;

namespace Open.Tests.Infra.Person
{
    [TestClass]
    public class PersonObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PersonObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(new PersonObjectsRepository(null));
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
        public void GetPersonByIDCodeTest()
        {
            Assert.Inconclusive();
        }
    }
}