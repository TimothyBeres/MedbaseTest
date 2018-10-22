using Open.Infra.Location;
using Open.Infra.Money;
using Open.Infra.Person;
using Open.Infra.Product;

namespace Open.Infra
{
    public static class DbTablesInitializer
    {
        public static void Initialize(SentryDbContext dbContext)
        {
            CountriesDbTableInitializer.Initialize(dbContext);
            CurrenciesDbTableInitializer.Initialize(dbContext);
            CountryCurrenciesDbTableInitializer.Initialize(dbContext);
            AddressDbTableInitializer.Initialize(dbContext);
            EffectsDbTableInitializer.Initialize(dbContext);
            MedicinesDbTableInitializer.Initialize(dbContext);
            MedicineEffectsDbTableInitializer.Initialize(dbContext);
          //  PersonsDbTableInitializer.Initialize(dbContext);
        }
    }
}