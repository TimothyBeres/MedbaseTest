using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Infra;

namespace Open.Tests.Infra
{
    [TestClass]
    public class ObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ObjectsRepository<CountryObject, CountryDbRecord>);
        }

        [TestMethod]
        public void IsInitializedTest()
        {
            Assert.Inconclusive();
        }
    }
}