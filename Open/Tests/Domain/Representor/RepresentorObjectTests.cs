using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Representor;
using Open.Domain.Product;
using Open.Domain.Representor;

namespace Open.Tests.Domain.Representor
{
    [TestClass]
    public class RepresentorObjectTests : DomainObjectTests<RepresentorObject, RepresentorDbRecord>
    {
        protected override RepresentorObject getRandomTestObject()
        {
            createdWithNullArg = new RepresentorObject(null);
            dbRecordType = typeof(RepresentorDbRecord);
            return GetRandom.Object<RepresentorObject>();
        }
        [TestMethod]
        public void RepresentedMedicinesTest()
        {
            Assert.IsNotNull(obj.RepresentedMedicines);
            Assert.IsInstanceOfType(obj.RepresentedMedicines, typeof(IReadOnlyList<MedicineObject>));
        }

        [TestMethod]
        public void RepresentedMedicineTest()
        {
            var medicine = GetRandom.Object<MedicineObject>();
            Assert.IsFalse(obj.RepresentedMedicines.Contains(medicine));
            obj.RepresentedMedicine(medicine);
            Assert.IsTrue(obj.RepresentedMedicines.Contains(medicine));
        }
    }
}
