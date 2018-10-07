using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Infra;

namespace Open.Tests.Infra
{
    [TestClass]
    public class PaginatedRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PaginatedRepository<CountryObject, CountryDbRecord>);
        }

        [TestMethod]
        public void SearchStringTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void PageIndexTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void PageSizeTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void SortOrderTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void SortFunctionTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetObjectsListTest()
        {
            Assert.Inconclusive();
        }
    }
}