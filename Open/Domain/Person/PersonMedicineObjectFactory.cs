using System;
using Open.Core;
using Open.Data.Person;
using Open.Data.Product;
using Open.Domain.Product;

namespace Open.Domain.Person
{
    public static class PersonMedicineObjectFactory
    {
        public static PersonMedicineObject Create(PersonObject person, MedicineObject medicine, Suitability suitableForPerson,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var o = new PersonMedicineDbRecord
            {
                Person = person?.DbRecord ?? new PersonDbRecord(),
                Medicine = medicine?.DbRecord ?? new MedicineDbRecord(),
                Suitability = suitableForPerson,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.PersonID = o.Person.ID;
            o.MedicineID = o.Medicine.ID;
            return new PersonMedicineObject(o);
        }
    }
}