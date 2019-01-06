using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Representor;
using Open.Domain.Representor;

namespace Open.Tests.Domain.Representor
{
    [TestClass]
    public class MedicineRepresentorsObjectTests : ObjectTests<MedicineRepresentorsObject>
    {
        protected override MedicineRepresentorsObject getRandomTestObject()
        {
            return GetRandom.Object<MedicineRepresentorsObject>();
        }

        [TestMethod]
        public void MedicineTest()
        {
            Assert.AreEqual(obj.Medicine.DbRecord, obj.DbRecord.Medicine);
        }

        [TestMethod]
        public void RepresentorTest()
        {
            Assert.AreEqual(obj.Representor.DbRecord, obj.DbRecord.Representor);
        }

        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new MedicineRepresentorsObject(null);
            Assert.AreEqual(obj.Medicine.DbRecord, obj.DbRecord.Medicine);
            Assert.AreEqual(obj.Representor.DbRecord, obj.DbRecord.Representor);
        }
    }
}
