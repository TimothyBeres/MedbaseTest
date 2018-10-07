using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;

namespace Open.Tests.Aids
{
    [TestClass]
    public class PublicBindingFlagsForTests : BaseTests
    {
        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        private Type testType;

        internal class TestClass
        {
            public void Aaa()
            {
                Bbb();
            }
            private void Bbb() { }
            public static void Ccc()
            {
                Ddd();
            }
            private static void Ddd() { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(PublicBindingFlagsFor);
            testType = typeof(TestClass);
        }

        [TestMethod]
        public void AllMembersTest()
        {
            testMembers(i | s | p, PublicBindingFlagsFor.AllMembers, 7);
        }

        [TestMethod]
        public void InstanceMembersTest()
        {
            testMembers(i | p, PublicBindingFlagsFor.InstanceMembers, 6);
        }

        [TestMethod]
        public void StaticMembersTest()
        {
            testMembers(s | p, PublicBindingFlagsFor.StaticMembers, 1);
        }

        [TestMethod]
        public void DeclaredMembersTest()
        {
            testMembers(d | i | s | p, PublicBindingFlagsFor.DeclaredMembers, 3);
        }

        private void testMembers(BindingFlags expected, BindingFlags actual,
            int membersCount)
        {
            var a = testType.GetMembers(actual);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(membersCount, a.Length);
        }
    }
}
