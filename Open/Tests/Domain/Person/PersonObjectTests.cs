using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Person;
using Open.Domain.Person;
using Open.Domain.Product;

namespace Open.Tests.Domain.Person
{
    [TestClass]
    public class PersonObjectTests : DomainObjectTests<PersonObject, PersonDbRecord>
    {
        protected override PersonObject getRandomTestObject()
        {
            createdWithNullArg = new PersonObject(null);
            dbRecordType = typeof(PersonDbRecord);
            return GetRandom.Object<PersonObject>();
        }

        [TestMethod]
        public void MedicinesInUseTest()
        {
            Assert.IsNotNull(obj.MedicinesInUse);
            Assert.IsInstanceOfType(obj.MedicinesInUse, typeof(IReadOnlyList<MedicineObject>));
        }

        [TestMethod]
        public void MedicineInUseTest()
        {
            var medicine = GetRandom.Object<MedicineObject>();
            Assert.IsFalse(obj.MedicinesInUse.Contains(medicine));
            obj.MedicineInUse(medicine);
            Assert.IsTrue(obj.MedicinesInUse.Contains(medicine));
        }
    }
}