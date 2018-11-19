using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Data.Money;
using Open.Data.Person;
using Open.Data.Product;
using Open.Infra;
using Open.Tests.Infra.Location;

namespace Open.Tests.Infra
{
    [TestClass]
    public class SentryDbContextTests : BaseTests
    {
        private class testClass : SentryDbContext
        {
            public testClass(DbContextOptions<SentryDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);
                return mb;
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(SentryDbContext);
        }

        [TestMethod]
        public void CountriesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CurrenciesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void PersonsTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void CountryCurrenciesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddressesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void TelecomDeviceRegistrationsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProductsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CataloguesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ProductCataloguesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void EffectsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MedicinesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MedicineEffectsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void PersonMedicinesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CreateAddressTableTest()
        {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.CreateAddressTable(mb);
            testHasAddressEntities(mb);
        }

        [TestMethod]
        public void CreateCountryCurrencyTableTest()
        {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.CreateCountryCurrencyTable(mb);
            testHasCountryCurrencyEntities(mb);
        }

        [TestMethod]
        public void CreateTelecomAddressRegistrationTableTest()
        {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.CreateTelecomAddressRegistrationTable(mb);
            testHasTelecomRegistrationEntities(mb);
        }

        [TestMethod]
        public void CreateMedicineEffectsTableTest()
        {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.CreateMedicineEffectsTable(mb);
            testHasMedicineEffectsEntities(mb);
        }

        [TestMethod]
        public void CreatePersonMedicinesTableTest()
        {
            var set = new ConventionSet();
            var mb = new ModelBuilder(set);
            SentryDbContext.CreatePersonMedicinesTable(mb);
            testHasPersonMedicinesEntities(mb);
        }

        [TestMethod]
        public void OnModelCreatingTest()
        {
            var o = new DbContextOptions<SentryDbContext>();
            var context = new testClass(o);
            var mb = context.RunOnModelCreating();
            testHasAddressEntities(mb);
            testHasCountryCurrencyEntities(mb);
            testOtherTelecomRegistrationEntities(mb);
        }

        private static void testHasTelecomRegistrationEntities(ModelBuilder mb)
        {
            testEntity<GeographicAddressDbRecord>(mb);
            testOtherTelecomRegistrationEntities(mb);
        }

        private static void testOtherTelecomRegistrationEntities(ModelBuilder mb)
        {
            testEntity<TelecomAddressDbRecord>(mb);
            var entity = testEntity<TelecomDeviceRegistrationDbRecord>(mb, true, 2);
            var adrID = GetMember.Name<TelecomDeviceRegistrationDbRecord>(x => x.AddressID);
            var devID = GetMember.Name<TelecomDeviceRegistrationDbRecord>(x => x.DeviceID);
            testPrimaryKey(entity, adrID, devID);
            testForeignKey(entity, adrID, typeof(GeographicAddressDbRecord));
            testForeignKey(entity, devID, typeof(TelecomAddressDbRecord));
        }

        private static void testHasCountryCurrencyEntities(ModelBuilder mb)
        {
            testEntity<CountryDbRecord>(mb);
            testEntity<CurrencyDbRecord>(mb);
            var entity = testEntity<CountryCurrencyDbRecord>(mb, true, 2);
            var countryID = GetMember.Name<CountryCurrencyDbRecord>(x => x.CountryID);
            var currencyID = GetMember.Name<CountryCurrencyDbRecord>(x => x.CurrencyID);
            testPrimaryKey(entity, countryID, currencyID);
            testForeignKey(entity, countryID, typeof(CountryDbRecord));
            testForeignKey(entity, currencyID, typeof(CurrencyDbRecord));
        }

        private static void testHasMedicineEffectsEntities(ModelBuilder mb)
        {
            testEntity<EffectDbRecord>(mb);
            testEntity<MedicineDbRecord>(mb);
            var entity = testEntity<MedicineEffectsDbRecord>(mb, true, 2);
            var medicineID = GetMember.Name<MedicineEffectsDbRecord>(x => x.MedicineID);
            var effectID = GetMember.Name<MedicineEffectsDbRecord>(x => x.EffectID);
            testPrimaryKey(entity, effectID, medicineID);
            testForeignKey(entity, effectID, typeof(EffectDbRecord));
            testForeignKey(entity, medicineID, typeof(MedicineDbRecord));
        }

        private static void testHasPersonMedicinesEntities(ModelBuilder mb)
        {
            testEntity<PersonDbRecord>(mb);
            testEntity<MedicineDbRecord>(mb);
            var entity = testEntity<PersonMedicineDbRecord>(mb, true, 2);
            var medicineID = GetMember.Name<PersonMedicineDbRecord>(x => x.MedicineID);
            var personID = GetMember.Name<PersonMedicineDbRecord>(x => x.PersonID);
            testPrimaryKey(entity, personID, medicineID);
            testForeignKey(entity, personID, typeof(PersonDbRecord));
            testForeignKey(entity, medicineID, typeof(MedicineDbRecord));
        }

        private static void testHasAddressEntities(ModelBuilder mb)
        {
            testEntity<CountryDbRecord>(mb);
            testEntity<AddressDbRecord>(mb);
            var entity = testEntity<GeographicAddressDbRecord>(mb, false, 1);
            var countryID = GetMember.Name<GeographicAddressDbRecord>(x => x.CountryID);
            testForeignKey(entity, countryID, typeof(CountryDbRecord));
            testEntity<WebPageAddressDbRecord>(mb);
            testEntity<EmailAddressDbRecord>(mb);
            testEntity<TelecomAddressDbRecord>(mb);
        }

        private static IMutableEntityType testEntity<T>(ModelBuilder mb, bool hasPrimaryKey = false,
            int foreignKeysCount = 0)
        {
            var name = typeof(T).FullName;
            var entity = mb.Model.FindEntityType(name);
            Assert.IsNotNull(entity, name);
            testPrimaryKey(entity, hasPrimaryKey);
            testForeignKey(entity, foreignKeysCount);
            return entity;
        }

        private static void testForeignKey(IMutableEntityType entity, int foreignKeysCount)
        {
            Assert.AreEqual(foreignKeysCount, entity.GetForeignKeys().Count());
        }

        private static void testPrimaryKey(IMutableEntityType entity, bool hasPrimaryKey)
        {
            if (hasPrimaryKey) Assert.IsNotNull(entity.FindPrimaryKey());
            else Assert.IsNull(entity.FindPrimaryKey());
        }

        private static void testForeignKey(IMutableEntityType entity, string name = null, Type t = null)
        {
            var keys = entity.GetForeignKeys();
            foreach (var k in keys)
            {
                var key = k.Properties.FirstOrDefault(x => x.Name == name);
                if (key is null) continue;
                Assert.AreEqual(k.PrincipalEntityType.Name, t?.FullName);
                return;
            }
            Assert.Fail("No foreign key found");
        }

        private static void testPrimaryKey(IMutableEntityType entity, params string[] values)
        {
            var key = entity.FindPrimaryKey();
            if (values is null) Assert.IsNull(key);
            else
                foreach (var v in values)
                {
                    Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == v));
                }
        }
    }
}