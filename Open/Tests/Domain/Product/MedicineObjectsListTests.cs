using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class MedicineObjectsListTests : DomainObjectsListTests<MedicineObjectsList, MedicineObject>
    {
        protected override MedicineObjectsList getRandomTestObject()
        {
            createWithNullArgs = new MedicineObjectsList(null, null);
            var l = GetRandom.Object<List<MedicineDbRecord>>();
            return new MedicineObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}