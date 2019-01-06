using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Representor;
using Open.Tests.Aids;
using Open.Tests.Data.Common;

namespace Open.Tests.Data.Representor
{
    [TestClass]
    public class MedicineRepresentorDbRecordTests : ObjectTests<MedicineRepresentorDbRecord>
    {
        protected override MedicineRepresentorDbRecord getRandomTestObject()
        {
            return GetRandom.Object<MedicineRepresentorDbRecord>();
        }
        [TestMethod]
        public void MedicineIDTest()
        {
            testReadWriteProperty(() => obj.MedicineID, x => obj.MedicineID = x);
            testNullEmptyAndWhitespaceCases(() => obj.MedicineID, x => obj.MedicineID = x, () => Open.Core.Constants.Unspecified);
        }

        [TestMethod]
        public void RepresentorIDTest()
        {
            testReadWriteProperty(() => obj.RepresentorID, x => obj.RepresentorID = x);
            testNullEmptyAndWhitespaceCases(() => obj.RepresentorID, x => obj.RepresentorID = x, () => Open.Core.Constants.Unspecified);
        }

        [TestMethod]
        public void RepresentorTest()
        {
            testReadWriteProperty(() => obj.Representor, x => obj.Representor = x);
            obj.Representor = null;
            Assert.IsNull(obj.Representor);
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
