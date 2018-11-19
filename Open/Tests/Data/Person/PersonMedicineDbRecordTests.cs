using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Person;

namespace Open.Tests.Data.Person
{
    [TestClass]
    public class PersonMedicineDbRecordTests : ObjectTests<PersonMedicineDbRecord>
    {
        protected override PersonMedicineDbRecord getRandomTestObject()
        {
            return GetRandom.Object<PersonMedicineDbRecord>();
        }

        [TestMethod]
        public void MedicineIDTest()
        {
            testReadWriteProperty(() => obj.MedicineID, x => obj.MedicineID = x);
            testNullEmptyAndWhitespaceCases(() => obj.MedicineID, x => obj.MedicineID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void PersonIDTest()
        {
            testReadWriteProperty(() => obj.PersonID, x => obj.PersonID = x);
            testNullEmptyAndWhitespaceCases(() => obj.PersonID, x => obj.PersonID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void SuitableForPersonTest()
        {
            testReadWriteProperty(() => obj.SuitableForPerson, x => obj.SuitableForPerson = x);
            // testNullEmptyAndWhitespaceCases(() => obj.SuitableForPerson, x => obj.SuitableForPerson = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void PersonTest()
        {
            testReadWriteProperty(() => obj.Person, x => obj.Person = x);
            obj.Person = null;
            Assert.IsNull(obj.Person);
        }

        [TestMethod]
        public void MedicineTest()
        {
            testReadWriteProperty(() => obj.Medicine, x => obj.Medicine = x);
            obj.Medicine = null;
            Assert.IsNull(obj.Medicine);
        }
    }
}