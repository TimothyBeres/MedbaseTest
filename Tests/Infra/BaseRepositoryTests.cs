using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Infra;

namespace Open.Tests.Infra
{
    [TestClass]
    public class BaseRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(BaseRepository<CountryObject, CountryDbRecord>);
        }

        [TestMethod]
        public void GetObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void UpdateObjectTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void DeleteObjectTest()
        {
            Assert.Inconclusive();
        }
    }
}