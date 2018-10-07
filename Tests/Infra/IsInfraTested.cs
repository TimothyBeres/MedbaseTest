using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string assembly = "Open.Infra";

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
        public void IsProductTested()
        {
            isAllClassesTested(assembly, Namespace("Product"));
        }

        //[TestMethod]
        //public void IsTested()
        //{
        //    isAllClassesTested(base.Namespace("Infra"));
        //}
    }
}