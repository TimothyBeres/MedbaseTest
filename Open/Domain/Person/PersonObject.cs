using System.Collections.Generic;
using Open.Core;
using Open.Data.Person;
using Open.Domain.Common;
using Open.Domain.Product;

namespace Open.Domain.Person
{
    public sealed class PersonObject : UniqueObject<PersonDbRecord>
    {
        private readonly List<MedicineObject> medicineInUse;

        public PersonObject(PersonDbRecord r) : base(r ?? new PersonDbRecord())
        {
            medicineInUse = new List<MedicineObject>();
        }

        public IReadOnlyList<MedicineObject> MedicinesInUse =>
            medicineInUse.AsReadOnly();

        public void MedicineInUse(MedicineObject medicineObject)
        {
            if (medicineObject is null) return;
            if (medicineObject.DbRecord.ID == Constants.Unspecified) return;
            if (medicineInUse.Find(x => x.DbRecord.ID == medicineObject.DbRecord.ID) != null)
                return;
            medicineInUse.Add(medicineObject);
        }
    }
}