using System;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public static class CategoryMedicineObjectFactory
    {
        public static CategoryMedicineObject Create(CategoryObject category, MedicineObject medicine,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var o = new CategoryMedicineDbRecord
            {
                Category = category?.DbRecord ?? new CategoryDbRecord(),
                Medicine = medicine?.DbRecord ?? new MedicineDbRecord(),
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.CategoryID = o.Category.ID;
            o.MedicineID = o.Medicine.ID;
            return new CategoryMedicineObject(o);
        }
    }
}