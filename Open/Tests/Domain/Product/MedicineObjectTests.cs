using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class MedicineObjectTests : DomainObjectTests<MedicineObject, MedicineDbRecord>
    {
        protected override MedicineObject getRandomTestObject()
        {
            createdWithNullArg = new MedicineObject(null);
            dbRecordType = typeof(MedicineDbRecord);
            return GetRandom.Object<MedicineObject>();
        }

        [TestMethod]
        public void EffectsInMedicinesTest()
        {
            Assert.IsNotNull(obj.EffectsInMedicines);
            Assert.IsInstanceOfType(obj.EffectsInMedicines, typeof(IReadOnlyList<EffectObject>));
        }

        [TestMethod]
        public void EffectsInMedicineTest()
        {
            var product = GetRandom.Object<EffectObject>();
            Assert.IsFalse(obj.EffectsInMedicines.Contains(product));
            obj.EffectsInMedicine(product);
            Assert.IsTrue(obj.EffectsInMedicines.Contains(product));
        }
    }
}