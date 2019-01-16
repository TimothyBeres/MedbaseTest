using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Person;

namespace Open.Tests.Facade.Person
{
    [TestClass]
    public class PersonInfoViewModelFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PersonInfoViewModelFactory);
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
