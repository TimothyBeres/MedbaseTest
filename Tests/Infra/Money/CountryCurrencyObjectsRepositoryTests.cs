using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money
{
    [TestClass]
    public class CountryCurrencyObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CountryCurrencyObjectsRepository);
        }

        [TestMethod]
        public void GetObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void AddObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void UpdateObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void DeleteObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void LoadCountriesTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void LoadCurrenciesTest() { Assert.Inconclusive(); }
    }
}