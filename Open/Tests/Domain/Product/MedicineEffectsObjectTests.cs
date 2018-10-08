using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class MedicineEffectsObjectTests : ObjectTests<MedicineEffectsObject>
    {
        protected override MedicineEffectsObject getRandomTestObject()
        {
            return GetRandom.Object<MedicineEffectsObject>();
        }

        [TestMethod]
        public void EffectTest()
        {
            Assert.AreEqual(obj.Effect.DbRecord, obj.DbRecord.Effect);
        }

        [TestMethod]
        public void MedicineTest()
        {
            Assert.AreEqual(obj.Medicine.DbRecord, obj.DbRecord.Medicine);
        }

        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new MedicineEffectsObject(null);
            Assert.AreEqual(obj.Medicine.DbRecord, obj.DbRecord.Medicine);
            Assert.AreEqual(obj.Effect.DbRecord, obj.DbRecord.Effect);
        }
    }
}