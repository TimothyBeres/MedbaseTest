﻿using System;
using Open.Domain.Person;
using Open.Domain.Process;
using Open.Domain.Product;
using Open.Facade.Product;

namespace Open.Facade.Person
{
    public static class PersonInfoViewModelFactory
    {
        public static PersonInfoViewModel Create(DosageObject d, PersonMedicineObject pm, MedicineObject m)
        {
            var v = new PersonInfoViewModel()
            {
                ID = d?.DbRecord.PersonID,
                Suitable = pm?.DbRecord.SuitableForPerson,
                MedicineName = m?.DbRecord.Name,
                FormOfInjection = m?.DbRecord.FormOfInjection
            };
            if (d is null) return v;
            v.ValidFrom = setNullIfExtremum(d.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(d.DbRecord.ValidTo);
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