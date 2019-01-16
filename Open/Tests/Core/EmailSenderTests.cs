using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;

namespace Open.Tests.Core
{
    [TestClass]
    public class EmailSenderTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EmailSender);
        }

        [TestMethod]
        public void SendTest()
        {
            Assert.Inconclusive();
        }
    }
}
