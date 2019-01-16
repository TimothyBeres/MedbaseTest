using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Person;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class AskViewModelTests : ViewModelTests<AskViewModel, UniqueEntityViewModel>
    {
        protected override AskViewModel getRandomTestObject()
        {
            return GetRandom.Object<AskViewModel>();
        }

        [TestMethod]
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }
        [TestMethod]
        public void EmailTest()
        {
            testReadWriteProperty(() => obj.Email, x => obj.Email = x);
        }
        [TestMethod]
        public void SubjectTest()
        {
            testReadWriteProperty(() => obj.Subject, x => obj.Subject = x);
        }
        [TestMethod]
        public void MessageTest()
        {
            testReadWriteProperty(() => obj.Message, x => obj.Message = x);
        }

    }
}
