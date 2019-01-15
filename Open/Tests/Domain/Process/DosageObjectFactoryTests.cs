using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Tests.Domain.Process
{
    [TestClass]
    public class DosageObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(DosageObjectFactory);
        }

        private void testVariables(DosageDbRecord o, string id, TypeOfTreatment typeOfTreatment, string personId, string medicineId,
            DateTime vFrom, DateTime vTo)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(typeOfTreatment, o.TypeOfTreatment);
            Assert.AreEqual(personId, o.PersonID);
            Assert.AreEqual(medicineId, o.MedicineID);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<DosageDbRecord>();
            var o = DosageObjectFactory.Create(r.ID, r.TypeOfTreatment, r.PersonID, r.MedicineID, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(DosageObject));
            testVariables(o.DbRecord, r.ID, r.TypeOfTreatment, r.PersonID, r.MedicineID,
                 r.ValidFrom, r.ValidTo);
        }
    }
}