using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Tests.Domain.Process
{
    [TestClass]
    public class SchemeObjectsListTests : DomainObjectsListTests<SchemeObjectsList, SchemeObject>
    {
        protected override SchemeObjectsList getRandomTestObject()
        {
            createWithNullArgs = new SchemeObjectsList(null, null);
            var l = GetRandom.Object<List<SchemeDbRecord>>();
            return new SchemeObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}