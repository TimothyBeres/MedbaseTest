using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Process;
using Open.Domain.Process;

namespace Open.Tests.Domain.Process
{
    [TestClass]
    public class DosageObjectsListTests : DomainObjectsListTests<DosageObjectsList, DosageObject>
    {
        protected override DosageObjectsList getRandomTestObject()
        {
            createWithNullArgs = new DosageObjectsList(null, null);
            var l = GetRandom.Object<List<DosageDbRecord>>();
            return new DosageObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}