using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class MedicineEffectsObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineEffectsObjectFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<MedicineEffectsDbRecord>();
            var effect = new EffectObject(r.Effect);
            var medicine = new MedicineObject(r.Medicine);

            var o = MedicineEffectsObjectFactory.Create(effect, medicine, r.ValidFrom,
                r.ValidTo);

            Assert.AreEqual(o.DbRecord.ValidFrom, r.ValidFrom);
            Assert.AreEqual(o.DbRecord.ValidTo, r.ValidTo);
            Assert.AreEqual(o.Effect.DbRecord, r.Effect);
            Assert.AreEqual(o.Medicine.DbRecord, r.Medicine);
            Assert.AreEqual(o.DbRecord.EffectID, r.Effect.ID);
            Assert.AreEqual(o.DbRecord.MedicineID, r.Medicine.ID);
            Assert.AreEqual(o.DbRecord.Effect, r.Effect);
            Assert.AreEqual(o.DbRecord.Medicine, r.Medicine);
        }

        [TestMethod]
        public void CreateWithNullArgumentsTest()
        {
            var o = MedicineEffectsObjectFactory.Create(null, null);

            Assert.AreEqual(o.DbRecord.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(o.DbRecord.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(o.Effect.DbRecord, o.DbRecord.Effect);
            Assert.AreEqual(o.Medicine.DbRecord, o.DbRecord.Medicine);
            Assert.AreEqual(o.DbRecord.EffectID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.MedicineID, Constants.Unspecified);
        }
    }
}