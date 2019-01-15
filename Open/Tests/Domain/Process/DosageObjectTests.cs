using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Tests.Domain.Process
{
    [TestClass]
    public class DosageObjectTests : DomainObjectTests<DosageObject, DosageDbRecord>
    {
        protected override DosageObject getRandomTestObject()
        {
            createdWithNullArg = new DosageObject(null);
            dbRecordType = typeof(DosageDbRecord);
            return GetRandom.Object<DosageObject>();
        }

        [TestMethod]
        public void SchemesInUseTest()
        {
            Assert.IsNotNull(obj.SchemesInUse);
            Assert.IsInstanceOfType(obj.SchemesInUse, typeof(IReadOnlyList<SchemeObject>));
        }

        [TestMethod]
        public void SchemeInUseTest()
        {
            var medicine = GetRandom.Object<SchemeObject>();
            Assert.IsFalse(obj.SchemesInUse.Contains(medicine));
            obj.SchemeInUse(medicine);
            Assert.IsTrue(obj.SchemesInUse.Contains(medicine));
        }
    }
}