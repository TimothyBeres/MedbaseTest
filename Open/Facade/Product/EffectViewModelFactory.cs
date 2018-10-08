using System;
using Open.Domain.Product;

namespace Open.Facade.Product
{
    public static class EffectViewModelFactory
    {
        public static EffectViewModel Create(EffectObject o)
        {
            var v = new EffectViewModel
            {
                ID = o?.DbRecord.ID,
                Name = o?.DbRecord.Name,
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.DbRecord.ValidTo);
            foreach (var c in o.UsedInMedicines)
            {
                var medicine = MedicineViewModelFactory.Create(c);
                v.UsedInMedicines.Add(medicine);
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