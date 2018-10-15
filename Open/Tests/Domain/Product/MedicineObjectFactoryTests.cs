using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Tests.Domain.Product
{
    [TestClass]
    public class MedicineObjectFactoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(MedicineObjectFactory);
        }

        private void testVariables(MedicineDbRecord o, string id, string name, string atc_code, string form_of_injection, string strength,
            string manufacturer, string legal_status, string reimbursement, string spc, string pil, DateTime vFrom,
            DateTime vTo)
        {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(name, o.Name);
            Assert.AreEqual(atc_code, o.AtcCode);
            Assert.AreEqual(form_of_injection, o.FormOfInjection);
            Assert.AreEqual(strength, o.Strength);
            Assert.AreEqual(manufacturer, o.Manufacturer);
            Assert.AreEqual(legal_status, o.LegalStatus);
            Assert.AreEqual(reimbursement, o.Reimbursement);
            Assert.AreEqual(spc, o.Spc);
            Assert.AreEqual(pil, o.Pil);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
        }

        [TestMethod]
        public void CreateTest()
        {
            var r = GetRandom.Object<MedicineDbRecord>();
            var o = MedicineObjectFactory.Create(r.ID, r.Name, r.AtcCode, r.FormOfInjection, r.Strength, r.Manufacturer,
                r.LegalStatus, r.Reimbursement, r.Spc, r.Pil, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(MedicineObject));
            testVariables(o.DbRecord, r.ID, r.Name, r.AtcCode, r.FormOfInjection, r.Strength, r.Manufacturer,
                r.LegalStatus, r.Reimbursement, r.Spc, r.Pil, r.ValidFrom, r.ValidTo);
        }
    }
}