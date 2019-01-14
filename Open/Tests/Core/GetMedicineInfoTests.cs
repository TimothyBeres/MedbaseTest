using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;

namespace Open.Tests.Core
{
    [TestClass]
    public class GetMedicineInfoTests : ClassTests<GetMedicineInfo>
    {
        [TestMethod]
        public void TeadmataTest()
        {
            Assert.AreEqual(0, (int)GetMedicineInfo.Teadmata);
        }
        [TestMethod]
        public void EmailTest()
        {
            Assert.AreEqual(1, (int)GetMedicineInfo.Email);
        }
        [TestMethod]
        public void SMSTest()
        {
            Assert.AreEqual(2, (int)GetMedicineInfo.SMS);
        }
        [TestMethod]
        public void PrintTest()
        {
            Assert.AreEqual(3, (int)GetMedicineInfo.Print);
        }
    }
}
