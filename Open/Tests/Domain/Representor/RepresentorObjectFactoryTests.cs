using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Representor;
using Open.Domain.Product;
using Open.Domain.Representor;
using Open.Tests.Aids;

namespace Open.Tests.Domain.Representor
{
    [TestClass]
    public class RepresentorObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(RepresentorObjectFactory);
        }

        private void testVariables(RepresentorDbRecord o, string id, string name, string email, DateTime vFrom,
            DateTime vTo)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(name, o.Name);
            Assert.AreEqual(email, o.Email);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<RepresentorDbRecord>();
            var o = RepresentorObjectFactory.Create(r.ID, r.Name, r.Email, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(RepresentorObject));
            testVariables(o.DbRecord, r.ID, r.Name, r.Email, r.ValidFrom, r.ValidTo);
        }

    }
}
