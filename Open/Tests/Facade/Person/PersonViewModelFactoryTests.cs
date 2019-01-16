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
            Assert.AreEqual(v.Address, o.DbRecord.Address);
            Assert.AreEqual(v.Email, o.DbRecord.Email);
            Assert.AreEqual(v.PhoneNumber, o.DbRecord.PhoneNumber);
            Assert.AreEqual(v.GetMedicineInfo, o.DbRecord.GetMedicineInfo);
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
            Assert.AreEqual(v.Address, Constants.Unspecified);
            Assert.AreEqual(v.Email, Constants.Unspecified);
            Assert.AreEqual(v.PhoneNumber, Constants.Unspecified);
            Assert.AreEqual(v.GetMedicineInfo, GetMedicineInfo.Teadmata);
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
            Assert.AreEqual(v.Address, o.DbRecord.Address);
            Assert.AreEqual(v.Email, o.DbRecord.Email);
            Assert.AreEqual(v.PhoneNumber, o.DbRecord.PhoneNumber);
            Assert.AreEqual(v.GetMedicineInfo, o.DbRecord.GetMedicineInfo);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }
}