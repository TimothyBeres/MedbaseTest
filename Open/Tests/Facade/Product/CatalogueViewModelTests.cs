using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class CatalogueViewModelTests : ViewModelTests<MedicineViewModel, UniqueEntityViewModel>
    {
        protected override MedicineViewModel getRandomTestObject()
        {
            return GetRandom.Object<MedicineViewModel>();
        }

        [TestMethod]
        public void CatalogueNameTest()
        {
            testReadWriteProperty(() => obj.CatalogueName, x => obj.CatalogueName = x);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            testReadWriteProperty(() => obj.Description, x => obj.Description = x);
        }

        [TestMethod]
        public void ProductsInCatalogueTest()
        {
            Assert.IsInstanceOfType(obj.ProductsInCatalogue, typeof(List<EffectViewModel>));
            var name = GetMember.Name<MedicineViewModel>(x => x.ProductsInCatalogue);
            Assert.IsTrue(IsReadOnly.Property<MedicineViewModel>(name));
        }
    }
}