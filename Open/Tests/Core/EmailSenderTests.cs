using System;
using System.Collections.Generic;
using System.Net.Mail;
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
            string email = "test@email.com";
            string body = "testBody";
            string subject = "testSubject";
            MailMessage send = EmailSender.Send(email, body, subject);
            Assert.IsTrue(send.Body == body);
            Assert.IsTrue(send.Subject==subject);
        }
    }
}
