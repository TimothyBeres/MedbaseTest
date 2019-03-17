using System;
using Open.Domain.Product;

namespace Open.Facade.Product
{
    public static class CategoryViewModelFactory
    {
        public static CategoryViewModel Create(CategoryObject o)
        {
            var v = new CategoryViewModel()
            {
                ID = o?.DbRecord.ID,
                UserID = o?.DbRecord.UserID,
                CategoryName = o?.DbRecord.CategoryName
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.DbRecord.ValidTo);
            foreach (var c in o.MedicinesWithCategory)
            {
                var medicine = MedicineViewModelFactory.Create(c);
                v.MedicinesWithCategory.Add(medicine);
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
