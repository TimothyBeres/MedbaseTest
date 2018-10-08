using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class EffectObjectTests : DomainObjectTests<EffectObject, EffectDbRecord>
    {
        protected override EffectObject getRandomTestObject()
        {
            createdWithNullArg = new EffectObject(null);
            dbRecordType = typeof(EffectDbRecord);
            return GetRandom.Object<EffectObject>();
        }

        [TestMethod]
        public void UsedInMedicinesTest()
        {
            Assert.IsNotNull(obj.UsedInMedicines);
            Assert.IsInstanceOfType(obj.UsedInMedicines, typeof(IReadOnlyList<MedicineObject>));
        }

        [TestMethod]
        public void UsedInMedicineTest()
        {
            var catalogue = GetRandom.Object<MedicineObject>();
            Assert.IsFalse(obj.UsedInMedicines.Contains(catalogue));
            obj.UsedInMedicine(catalogue);
            Assert.IsTrue(obj.UsedInMedicines.Contains(catalogue));
        }
    }
}