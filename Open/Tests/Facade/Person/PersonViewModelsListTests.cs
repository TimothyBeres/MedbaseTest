using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Person;
using Open.Facade.Person;

namespace Open.Tests.Facade.Person
{
    [TestClass]
    public class PersonViewModelsListTests : ObjectTests<PersonViewModelsList>
    {
        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(new PersonViewModelsList(null));
        }

        protected override PersonViewModelsList getRandomTestObject()
        {
            var l = new PersonObjectsList(null, null);
            SetRandom.Values(l);
            return new PersonViewModelsList(l);
        }
    }
}