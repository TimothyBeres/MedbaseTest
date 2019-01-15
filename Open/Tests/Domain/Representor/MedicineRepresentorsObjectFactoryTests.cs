using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Representor;
using Open.Domain.Product;
using Open.Domain.Representor;

namespace Open.Tests.Domain.Representor
{
    [TestClass]
    public class MedicineRepresentorsObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineRepresentorsObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<MedicineRepresentorDbRecord>();
            var representor = new RepresentorObject(r.Representor);
            var medicine = new MedicineObject(r.Medicine);

            var o = MedicineRepresentorsObjectFactory.Create(representor, medicine, r.ValidFrom,
                r.ValidTo);
            Assert.AreEqual(o.DbRecord.ValidFrom, r.ValidFrom);
            Assert.AreEqual(o.DbRecord.ValidTo, r.ValidTo);
            Assert.AreEqual(o.Representor.DbRecord, r.Representor);
            Assert.AreEqual(o.Medicine.DbRecord, r.Medicine);
            Assert.AreEqual(o.DbRecord.RepresentorID, r.Representor.ID);
            Assert.AreEqual(o.DbRecord.MedicineID, r.Medicine.ID);
            Assert.AreEqual(o.DbRecord.Representor, r.Representor);
            Assert.AreEqual(o.DbRecord.Medicine, r.Medicine);
        }

        [TestMethod]
        public void CreateWithNullTest()
        {
            var o = MedicineRepresentorsObjectFactory.Create(null, null);
            Assert.AreEqual(o.DbRecord.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(o.DbRecord.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(o.Representor.DbRecord, o.DbRecord.Representor);
            Assert.AreEqual(o.Medicine.DbRecord, o.DbRecord.Medicine);
            Assert.AreEqual(o.DbRecord.RepresentorID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.MedicineID, Constants.Unspecified);
        }

    }
}
