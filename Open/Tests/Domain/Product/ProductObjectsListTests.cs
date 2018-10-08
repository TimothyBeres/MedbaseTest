using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class ProductObjectsListTests : DomainObjectsListTests<EffectObjectsList, EffectObject>
    {
        protected override EffectObjectsList getRandomTestObject()
        {
            createWithNullArgs = new EffectObjectsList(null, null);
            var l = GetRandom.Object<List<EffectDbRecord>>();
            return new EffectObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}