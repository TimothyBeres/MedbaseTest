using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Location;

namespace Open.Tests.Infra.Location
{
    [TestClass]
    public class AddressObjectsRepositoryTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(AddressObjectsRepository);
        }

        [TestMethod]
        public void SearchStringTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void PageIndexTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void PageSizeTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void SortOrderTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void SortFunctionTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void GetObjectsListTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void GetObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void AddObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void UpdateObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void DeleteObjectTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void IsInitializedTest() { Assert.Inconclusive(); }

        [TestMethod]
        public void GetDevicesListTest() { Assert.Inconclusive(); }
    }
}