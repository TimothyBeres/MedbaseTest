using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Tests.Domain.Process
{
    [TestClass]
    public class SchemeObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SchemeObjectFactory);
        }

        private void testVariables(SchemeDbRecord o, string id, string dosageId, string queueNr, string length, string amount, string times,
            string timeOfDay, DateTime vFrom, DateTime vTo)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(dosageId, o.DosageId);
            Assert.AreEqual(queueNr, o.QueueNr);
            Assert.AreEqual(length, o.Length);
            Assert.AreEqual(amount, o.Amount);
            Assert.AreEqual(times, o.Times);
            Assert.AreEqual(timeOfDay, o.TimeOfDay);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<SchemeDbRecord>();
            var o = SchemeObjectFactory.Create(r.ID, r.DosageId, r.QueueNr, r.Length, r.Amount, r.Times, r.TimeOfDay, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(SchemeObject));
            testVariables(o.DbRecord, r.ID, r.DosageId, r.QueueNr, r.Length, r.Amount, r.Times, r.TimeOfDay,
                r.ValidFrom, r.ValidTo);
        }
    }
}