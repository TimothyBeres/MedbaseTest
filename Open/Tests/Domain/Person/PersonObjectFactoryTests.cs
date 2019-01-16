using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Person;
using Open.Domain.Person;

namespace Open.Tests.Domain.Person
{
    [TestClass]
    public class PersonObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PersonObjectFactory);
        }

        private void testVariables(PersonDbRecord o, string id, string id_code, string first_name, string last_name,
            string address, string email, string phone_number, GetMedicineInfo get_medicine_info,   DateTime vFrom,
            DateTime vTo)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(id_code, o.IDCode);
            Assert.AreEqual(first_name, o.FirstName);
            Assert.AreEqual(last_name, o.LastName);
            Assert.AreEqual(address, o.Address);
            Assert.AreEqual(email, o.Email);
            Assert.AreEqual(phone_number, o.PhoneNumber);
            Assert.AreEqual(get_medicine_info, o.GetMedicineInfo);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
            
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<PersonDbRecord>();
            var o = PersonObjectFactory.Create(r.ID, r.IDCode, r.FirstName, r.LastName,r.Address, r.Email, r.PhoneNumber, r.GetMedicineInfo, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(PersonObject));
            testVariables(o.DbRecord, r.ID, r.IDCode, r.FirstName, r.LastName,
                r.Address,r.Email,r.PhoneNumber,r.GetMedicineInfo, r.ValidFrom, r.ValidTo);
        }
    }
}