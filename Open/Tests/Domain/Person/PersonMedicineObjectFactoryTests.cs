using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Person;
using Open.Domain.Person;
using Open.Domain.Product;
using Open.Infra.Person;

namespace Open.Tests.Domain.Person
{
    [TestClass]
    public class PersonMedicineObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PersonMedicineObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<PersonMedicineDbRecord>();
            var person = new PersonObject(r.Person);
            var medicine = new MedicineObject(r.Medicine);

            var o = PersonMedicineObjectFactory.Create(person, medicine, r.Suitability, r.ValidFrom,
                r.ValidTo);

            Assert.AreEqual(o.DbRecord.ValidFrom, r.ValidFrom);
            Assert.AreEqual(o.DbRecord.ValidTo, r.ValidTo);
            Assert.AreEqual(o.DbRecord.Suitability, r.Suitability);
            Assert.AreEqual(o.Person.DbRecord, r.Person);
            Assert.AreEqual(o.Medicine.DbRecord, r.Medicine);
            Assert.AreEqual(o.DbRecord.PersonID, r.Person.ID);
            Assert.AreEqual(o.DbRecord.MedicineID, r.Medicine.ID);
            Assert.AreEqual(o.DbRecord.Person, r.Person);
            Assert.AreEqual(o.DbRecord.Medicine, r.Medicine);
        }

        [TestMethod]
        public void CreateWithNullArgumentsTest()
        {
            var o = PersonMedicineObjectFactory.Create(null, null, Suitability.Jah);

            Assert.AreEqual(o.DbRecord.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(o.DbRecord.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(o.Person.DbRecord, o.DbRecord.Person);
            Assert.AreEqual(o.Medicine.DbRecord, o.DbRecord.Medicine);
            Assert.AreEqual(o.DbRecord.PersonID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.MedicineID, Constants.Unspecified);
        }
    }
}