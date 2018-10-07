using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class ProductObjectTests : DomainObjectTests<EffectObject, EffectDbRecord>
    {
        protected override EffectObject getRandomTestObject()
        {
            createdWithNullArg = new EffectObject(null);
            dbRecordType = typeof(EffectDbRecord);
            return GetRandom.Object<EffectObject>();
        }

        [TestMethod]
        public void RegisteredInCataloguesTest()
        {
            Assert.IsNotNull(obj.RegisteredInCatalogues);
            Assert.IsInstanceOfType(obj.RegisteredInCatalogues, typeof(IReadOnlyList<MedicineObject>));
        }

        [TestMethod]
        public void RegisteredInCatalogueTest()
        {
            var catalogue = GetRandom.Object<MedicineObject>();
            Assert.IsFalse(obj.RegisteredInCatalogues.Contains(catalogue));
            obj.RegisteredInCatalogue(catalogue);
            Assert.IsTrue(obj.RegisteredInCatalogues.Contains(catalogue));
        }
    }
}