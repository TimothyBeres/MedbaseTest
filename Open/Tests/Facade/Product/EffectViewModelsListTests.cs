using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Product;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class EffectViewModelsListTests : ObjectTests<EffectViewModelsList>
    {
        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new EffectViewModelsList(null));
        }

        protected override EffectViewModelsList getRandomTestObject()
        {
            var l = new EffectObjectsList(null, null);
            SetRandom.Values(l);
            return new EffectViewModelsList(l);
        }
    }
}