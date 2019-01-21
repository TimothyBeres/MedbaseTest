using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;

namespace Open.Tests.Core
{
    [TestClass]
    public class SuitabilityTests : ClassTests<Suitability>
    {
        [TestMethod]
        public void EiTest()
        {
            Assert.AreEqual(2, (int)Suitability.Ei);
        }
        [TestMethod]
        public void JahTest()
        {
            Assert.AreEqual(1, (int)Suitability.Jah);
        }
        [TestMethod]
        public void TeadmataTest()
        {
            Assert.AreEqual(0, (int)Suitability.Teadmata);
        }
    }
}
