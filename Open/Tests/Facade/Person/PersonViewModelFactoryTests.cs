using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Person;
using Open.Facade.Person;

namespace Open.Tests.Facade.Person
{
    [TestClass]
    public class PersonViewModelFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PersonViewModelFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var o = GetRandom.Object<PersonObject>();
            var v = PersonViewModelFactory.Create(o);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.IDCode, o.DbRecord.IDCode);
            Assert.AreEqual(v.FirstName, o.DbRecord.FirstName);
            Assert.AreEqual(v.LastName, o.DbRecord.LastName);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
        }

        [TestMethod]
        public void CreateNullTest()
        {
            var v = PersonViewModelFactory.Create(null);
            Assert.AreEqual(v.ID, Constants.Unspecified);
            Assert.AreEqual(v.IDCode, Constants.Unspecified);
            Assert.AreEqual(v.FirstName, Constants.Unspecified);
            Assert.AreEqual(v.LastName, Constants.Unspecified);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }

        public void setNullIfExtremumTest()
        {
            var o = GetRandom.Object<PersonObject>();
            o.DbRecord.ValidFrom = DateTime.MinValue;
            o.DbRecord.ValidTo = DateTime.MaxValue;
            var v = PersonViewModelFactory.Create(o);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.IDCode, o.DbRecord.IDCode);
            Assert.AreEqual(v.FirstName, o.DbRecord.FirstName);
            Assert.AreEqual(v.LastName, o.DbRecord.LastName);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }
}