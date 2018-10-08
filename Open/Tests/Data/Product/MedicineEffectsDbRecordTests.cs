using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;

namespace Open.Tests.Data.Product
{
    [TestClass]
    public class MedicineEffectsDbRecordTests : ObjectTests<MedicineEffectsDbRecord>
    {
        protected override MedicineEffectsDbRecord getRandomTestObject()
        {
            return GetRandom.Object<MedicineEffectsDbRecord>();
        }

        [TestMethod]
        public void MedicineIDTest()
        {
            testReadWriteProperty(() => obj.MedicineID, x => obj.MedicineID = x);
            testNullEmptyAndWhitespaceCases(() => obj.MedicineID, x => obj.MedicineID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void EffectIDTest()
        {
            testReadWriteProperty(() => obj.EffectID, x => obj.EffectID = x);
            testNullEmptyAndWhitespaceCases(() => obj.EffectID, x => obj.EffectID = x, () => Constants.Unspecified);
        }

        [TestMethod]
        public void EffectTest()
        {
            testReadWriteProperty(() => obj.Effect, x => obj.Effect = x);
            obj.Effect = null;
            Assert.IsNull(obj.Effect);
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