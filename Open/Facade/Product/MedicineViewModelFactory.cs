using System;
using Open.Domain.Product;

namespace Open.Facade.Product
{
    public static class MedicineViewModelFactory
    {
        public static MedicineViewModel Create(MedicineObject o)
        {
            var v = new MedicineViewModel
            {
                ID = o?.DbRecord.ID,
                Name = o?.DbRecord.Name,
                AtcCode = o?.DbRecord.AtcCode,
                FormOfInjection = o?.DbRecord.FormOfInjection,
                Strength = o?.DbRecord.Strength,
                Manufacturer = o?.DbRecord.Manufacturer,
                LegalStatus = o?.DbRecord.LegalStatus,
                Reimbursement = o?.DbRecord.Reimbursement,
                Spc = o?.DbRecord.Spc,
                Pil = o?.DbRecord.Pil
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.DbRecord.ValidTo);
            foreach (var c in o.EffectsInMedicines)
            {
                var product = EffectViewModelFactory.Create(c);
                v.EffectsInMedicine.Add(product);
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