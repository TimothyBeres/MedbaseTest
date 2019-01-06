using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Representor;
using Open.Domain.Representor;

namespace Open.Tests.Domain.Representor
{
    [TestClass]
    public class RepresentorObjectsListTests : DomainObjectsListTests<RepresentorObjectsList, RepresentorObject>
    {
        protected override RepresentorObjectsList getRandomTestObject()
        {
            createWithNullArgs = new RepresentorObjectsList(null, null);
            var l = GetRandom.Object<List<RepresentorDbRecord>>();
            return new RepresentorObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}
