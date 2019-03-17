using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Product;
using Open.Domain.Common;
using Open.Core;

namespace Open.Domain.Product
{
    public sealed class CategoryObject : UniqueObject<CategoryDbRecord>
    {
        private readonly List<MedicineObject> medicinesWithCategory;
        public CategoryObject(CategoryDbRecord r) : base(r ?? new CategoryDbRecord())
        {
            medicinesWithCategory = new List<MedicineObject>();
        }
        public IReadOnlyList<MedicineObject> MedicinesWithCategory =>
            medicinesWithCategory.AsReadOnly();

        public void MedicineWithCategory(MedicineObject medicineObject)
        {
            if (medicineObject is null) return;
            if (medicineObject.DbRecord.ID == Constants.Unspecified) return;
            if (medicinesWithCategory.Find(x => x.DbRecord.ID == medicineObject.DbRecord.ID) != null)
                return;
            medicinesWithCategory.Add(medicineObject);
        }
    }
}
