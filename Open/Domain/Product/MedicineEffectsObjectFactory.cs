using System;
using Open.Data.Effect;

namespace Open.Domain.Product
{
    public static class MedicineEffectsObjectFactory
    {
        public static MedicineEffectsObject Create(EffectObject effect, MedicineObject medicine,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var o = new MedicineEffectsDbRecord
            {
                Effect = effect?.DbRecord ?? new EffectDbRecord(),
                Medicine = medicine?.DbRecord ?? new MedicineDbRecord(),
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.EffectID = o.Effect.ID;
            o.MedicineID = o.Medicine.ID;
            return new MedicineEffectsObject(o);
        }
    }
}