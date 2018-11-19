using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Person;

namespace Open.Tests.Domain.Person
{
    [TestClass]
    public class PersonMedicineObjectTests : ObjectTests<PersonMedicineObject>
    {
        protected override PersonMedicineObject getRandomTestObject()
        {
            return GetRandom.Object<PersonMedicineObject>();
        }

        [TestMethod]
        public void PersonTest()
        {
            Assert.AreEqual(obj.Person.DbRecord, obj.DbRecord.Person);
        }

        [TestMethod]
        public void MedicineTest()
        {
            Assert.AreEqual(obj.Medicine.DbRecord, obj.DbRecord.Medicine);
        }

        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new PersonMedicineObject(null);
            Assert.AreEqual(obj.Medicine.DbRecord, obj.DbRecord.Medicine);
            Assert.AreEqual(obj.Person.DbRecord, obj.DbRecord.Person);
        }
    }
}