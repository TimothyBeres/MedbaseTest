using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Process;

namespace Open.Tests.Data.Process
{
    [TestClass]
    public class SchemeDbRecordTests : ObjectTests<SchemeDbRecord>
    {
        protected override SchemeDbRecord getRandomTestObject()
        {
            return GetRandom.Object<SchemeDbRecord>();
        }

        [TestMethod]
        public void IsInstanceOfUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(SchemeDbRecord).BaseType);
        }

        [TestMethod]
        public void DosageIdTest()
        {
            testReadWriteProperty(() => obj.DosageId, x => obj.DosageId = x);
        }

        [TestMethod]
        public void QueueNrTest()
        {
            testReadWriteProperty(() => obj.QueueNr, x => obj.QueueNr = x);
        }

        [TestMethod]
        public void LengthTest()
        {
            testReadWriteProperty(() => obj.Length, x => obj.Length = x);
        }

        [TestMethod]
        public void AmountTest()
        {
            testReadWriteProperty(() => obj.Amount, x => obj.Amount = x);
        }

        [TestMethod]
        public void TimesTest()
        {
            testReadWriteProperty(() => obj.Times, x => obj.Times = x);
        }

        [TestMethod]
        public void TimeOfDayTest()
        {
            testReadWriteProperty(() => obj.TimeOfDay, x => obj.TimeOfDay = x);
        }
    }
}