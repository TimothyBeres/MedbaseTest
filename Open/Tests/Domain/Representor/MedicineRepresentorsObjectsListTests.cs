using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Representor;
using Open.Domain.Product;
using Open.Domain.Representor;

namespace Open.Tests.Domain.Representor
{
    [TestClass]
    public class MedicineRepresentorsObjectsListTests : DomainObjectsListTests<MedicineRepresentorsObjectsList, MedicineRepresentorsObject>
    {
        protected override MedicineRepresentorsObjectsList getRandomTestObject()
        {
            createWithNullArgs = new MedicineRepresentorsObjectsList(null, null);
            var l = GetRandom.Object<List<MedicineRepresentorDbRecord>>();
            return new MedicineRepresentorsObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}
