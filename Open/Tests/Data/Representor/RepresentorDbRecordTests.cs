using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Representor;

namespace Open.Tests.Data.Representor
{
    [TestClass]
    public class RepresentorDbRecordTests : ObjectTests<RepresentorDbRecord>
    {
        protected override RepresentorDbRecord getRandomTestObject()
        {
            return GetRandom.Object<RepresentorDbRecord>();
        }
        [TestMethod]
        public void IsInstanceOfUniqueDbRecord()
        {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(RepresentorDbRecord).BaseType);
        }

        [TestMethod]
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }
        [TestMethod]
        public void EmailTest()
        {
            testReadWriteProperty(() => obj.Email, x => obj.Email = x);
        }
    }
}
