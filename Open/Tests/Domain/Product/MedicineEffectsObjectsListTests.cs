using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class MedicineEffectsObjectsListTests : DomainObjectsListTests<MedicineEffectsObjectsList, MedicineEffectsObject>
    {
        protected override MedicineEffectsObjectsList getRandomTestObject()
        {
            createWithNullArgs = new MedicineEffectsObjectsList(null, null);
            var l = GetRandom.Object<List<MedicineEffectsDbRecord>>();
            return new MedicineEffectsObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}