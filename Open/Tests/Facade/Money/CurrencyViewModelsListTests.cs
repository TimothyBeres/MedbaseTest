using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Money;
using Open.Facade.Money;

namespace Open.Tests.Facade.Money
{
    [TestClass]
    public class CurrencyViewModelsListTests : ObjectTests<CurrencyViewModelsList>
    {
        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new CurrencyViewModelsList(null));
        }

        protected override CurrencyViewModelsList getRandomTestObject()
        {
            var l = new CurrencyObjectsList(null, null);
            SetRandom.Values(l);
            return new CurrencyViewModelsList(l);
        }
    }
}