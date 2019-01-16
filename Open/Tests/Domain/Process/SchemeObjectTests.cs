using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Tests.Domain.Process
{
    [TestClass]
    public class SchemeObjectTests : DomainObjectTests<SchemeObject, SchemeDbRecord>
    {
        protected override SchemeObject getRandomTestObject()
        {
            createdWithNullArg = new SchemeObject(null);
            dbRecordType = typeof(SchemeDbRecord);
            return GetRandom.Object<SchemeObject>();
        }


    }
}