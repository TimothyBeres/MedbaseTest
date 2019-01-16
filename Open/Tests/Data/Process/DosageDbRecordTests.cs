using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Process;

namespace Open.Tests.Data.Process
{
    [TestClass]
    public class DosageDbRecordTests : ObjectTests<DosageDbRecord>
    {
        protected override DosageDbRecord getRandomTestObject()
        {
            return GetRandom.Object<DosageDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(DosageDbRecord).BaseType);
        }

        [TestMethod]
        public void TypeOfTreatmentTest()
        {
            testReadWriteProperty(() => obj.TypeOfTreatment, x => obj.TypeOfTreatment = x);
        }

        [TestMethod]
        public void PersonIDTest()
        {
            testReadWriteProperty(() => obj.PersonID, x => obj.PersonID = x);
        }

        [TestMethod]
        public void MedicineIDTest()
        {
            testReadWriteProperty(() => obj.MedicineID, x => obj.MedicineID = x);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
        }
    }
}