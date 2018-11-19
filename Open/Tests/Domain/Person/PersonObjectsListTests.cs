using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Person;
using Open.Domain.Person;

namespace Open.Tests.Domain.Person
{
    [TestClass]
    public class PersonObjectsListTests : DomainObjectsListTests<PersonObjectsList, PersonObject>
    {
        protected override PersonObjectsList getRandomTestObject()
        {
            createWithNullArgs = new PersonObjectsList(null, null);
            var l = GetRandom.Object<List<PersonDbRecord>>();
            return new PersonObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}