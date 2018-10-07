using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class ProductViewModelTests : ViewModelTests<EffectViewModel, UniqueEntityViewModel>
    {
        protected override EffectViewModel getRandomTestObject()
        {
            return GetRandom.Object<EffectViewModel>();
        }

        [TestMethod]
        public void ProductNameTest()
        {
            testReadWriteProperty(() => obj.ProductName, x => obj.ProductName = x);
        }

        [TestMethod]
        public void ProductTypeTest()
        {
            testReadWriteProperty(() => obj.ProductType, x => obj.ProductType = x);
        }

        [TestMethod]
        public void RegisteredInCataloguesTest()
        {
            Assert.IsInstanceOfType(obj.RegisteredInCatalogues, typeof(List<MedicineViewModel>));
            var name = GetMember.Name<EffectViewModel>(x => x.RegisteredInCatalogues);
            Assert.IsTrue(IsReadOnly.Property<EffectViewModel>(name));
        }
    }
}