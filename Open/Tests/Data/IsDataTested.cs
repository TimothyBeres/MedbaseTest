﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        private const string assembly = "Open.Data";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }

        [TestMethod]
        public void IsLocationTested()
        {
            isAllClassesTested(assembly, Namespace("Location"));
        }

        [TestMethod]
        public void IsMoneyTested()
        {
            isAllClassesTested(assembly, Namespace("Money"));
        }

        [TestMethod]
        public void IsQuantityTested()
        {
            isAllClassesTested(assembly, Namespace("Quantity"));
        }

        [TestMethod]
        public void IsCommonTested()
        {
            isAllClassesTested(assembly, Namespace("Common"));
        }

        [TestMethod]
        public void IsProductTested()
        {
            isAllClassesTested(assembly, Namespace("Product"));
        }

        [TestMethod]
        public void IsPersonTested()
        {
            isAllClassesTested(assembly, Namespace("Person"));
        }
        [TestMethod]
        public void IsRepresentorTested()
        {
            isAllClassesTested(assembly, Namespace("Representor"));
        }

        [TestMethod]
        public void IsProcessTested()
        {
            isAllClassesTested(assembly, Namespace("Process"));
        }
    }
}