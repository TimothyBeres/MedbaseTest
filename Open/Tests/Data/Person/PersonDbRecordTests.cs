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
    }
}