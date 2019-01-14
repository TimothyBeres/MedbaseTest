using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Representor;

namespace Open.Tests.Infra.Representor
{
    [TestClass]
    public class RepresentorObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(RepresentorObjectsRepository);
        }

        [TestMethod]
        public void CanCreate()
        {
            
            Assert.IsNotNull(new RepresentorObjectsRepository(null));
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
    }
}
