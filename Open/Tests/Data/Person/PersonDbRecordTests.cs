using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Person;

namespace Open.Tests.Data.Person
{
    [TestClass]
    public class PersonDbRecordTests : ObjectTests<PersonDbRecord>
    {
        protected override PersonDbRecord getRandomTestObject()
        {
            return GetRandom.Object<PersonDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(PersonDbRecord).BaseType);
        }

        [TestMethod]
        public void IDCodeTest()
        {
            testReadWriteProperty(() => obj.IDCode, x => obj.IDCode = x);
        }

        [TestMethod]
        public void FirstNameTest()
        {
            testReadWriteProperty(() => obj.FirstName, x => obj.FirstName = x);
        }

        [TestMethod]
        public void LastNameTest()
        {
            testReadWriteProperty(() => obj.LastName, x => obj.LastName = x);
        }
        [TestMethod]
        public void AddressTest()
        {
            testReadWriteProperty(() => obj.Address, x => obj.Address = x);
        }
        [TestMethod]
        public void EmailTest()
        {
            testReadWriteProperty(() => obj.Email, x => obj.Email = x);
        }
        [TestMethod]
        public void PhoneNumberTest()
        {
            testReadWriteProperty(() => obj.PhoneNumber, x => obj.PhoneNumber = x);
        }
        [TestMethod]
        public void GetMedicineInfoTest()
        {
            testReadWriteProperty(() => obj.GetMedicineInfo, x => obj.GetMedicineInfo = x);
        }
    }
}