using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;

namespace Open.Tests.Core
{
    [TestClass]
    public class TypeOfTreatmentTests : ClassTests<TypeOfTreatment>
    {
        [TestMethod]
        public void PidevTest()
        {
            Assert.AreEqual(0,(int)TypeOfTreatment.Pidev);
        }
        [TestMethod]
        public void FikseeritudTest()
        {
            Assert.AreEqual(1, (int)TypeOfTreatment.Fikseeritud);
        }
    }
}
