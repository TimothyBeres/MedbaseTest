using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Product;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class MedicineViewModelsListTests : ObjectTests<MedicineViewModelsList>
    {
        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new MedicineViewModelsList(null));
        }

        protected override MedicineViewModelsList getRandomTestObject()
        {
            var l = new MedicineObjectsList(null, null);
            SetRandom.Values(l);
            return new MedicineViewModelsList(l);
        }
    }
}