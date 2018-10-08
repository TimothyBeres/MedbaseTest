using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    /*[TestClass]
    public class CatalogueObjectTests : DomainObjectTests<MedicineObject, CatalogueDbRecord>
    {
        protected override MedicineObject getRandomTestObject()
        {
            createdWithNullArg = new MedicineObject(null);
            dbRecordType = typeof(CatalogueDbRecord);
            return GetRandom.Object<MedicineObject>();
        }

        [TestMethod]
        public void RegisteredInProductsTest()
        {
            Assert.IsNotNull(obj.RegisteredInProducts);
            Assert.IsInstanceOfType(obj.RegisteredInProducts, typeof(IReadOnlyList<EffectObject>));
        }

        [TestMethod]
        public void RegisteredInProductTest()
        {
            var product = GetRandom.Object<EffectObject>();
            Assert.IsFalse(obj.RegisteredInProducts.Contains(product));
            obj.RegisteredInProduct(product);
            Assert.IsTrue(obj.RegisteredInProducts.Contains(product));
        }
    }*/
}