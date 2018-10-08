using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Product;

namespace Open.Tests.Facade.Product
{
    [TestClass]
    public class EffectViewModelTests : ViewModelTests<EffectViewModel, UniqueEntityViewModel>
    {
        protected override EffectViewModel getRandomTestObject()
        {
            return GetRandom.Object<EffectViewModel>();
        }

        [TestMethod]
        public void NameTest()
        {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void UsedInMedicinesTest()
        {
            Assert.IsInstanceOfType(obj.UsedInMedicines, typeof(List<MedicineViewModel>));
            var name = GetMember.Name<EffectViewModel>(x => x.UsedInMedicines);
            Assert.IsTrue(IsReadOnly.Property<EffectViewModel>(name));
        }
    }
}