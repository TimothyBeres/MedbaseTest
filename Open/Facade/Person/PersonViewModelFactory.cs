using System;
using Open.Core;
using Open.Data.Person;
using Open.Domain.Person;
using Open.Facade.Product;

namespace Open.Facade.Person
{
    public static class PersonViewModelFactory
    {
        public static PersonViewModel Create(PersonObject o)
        {
            var v = new PersonViewModel()
            {
                ID = o?.DbRecord.ID,
                IDCode = o?.DbRecord.IDCode,
                FirstName = o?.DbRecord.FirstName,
                LastName = o?.DbRecord.LastName,
                Address = o?.DbRecord.Address,
                Email = o?.DbRecord.Email,
                PhoneNumber = o?.DbRecord.PhoneNumber,
                GetMedicineInfo = o?.DbRecord.GetMedicineInfo ?? GetMedicineInfo.Teadmata
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.DbRecord.ValidTo);
            foreach (var c in o.MedicinesInUse)
            {
                var product = MedicineViewModelFactory.Create(c);
                v.MedicinesInUse.Add(product);
            }
            return v;
        }

        private static DateTime? setNullIfExtremum(DateTime d)
        {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}