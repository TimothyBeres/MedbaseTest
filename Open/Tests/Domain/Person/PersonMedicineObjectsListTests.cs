using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Person;
using Open.Domain.Person;

namespace Open.Tests.Domain.Person
{
    [TestClass]
    public class PersonMedicineObjectsListTests : DomainObjectsListTests<PersonMedicineObjectsList, PersonMedicineObject>
    {
        protected override PersonMedicineObjectsList getRandomTestObject()
        {
            createWithNullArgs = new PersonMedicineObjectsList(null, null);
            var l = GetRandom.Object<List<PersonMedicineDbRecord>>();
            return new PersonMedicineObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}