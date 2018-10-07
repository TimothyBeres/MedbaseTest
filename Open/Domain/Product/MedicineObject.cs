using System.Collections.Generic;
using Open.Core;
using Open.Data.Product;
using Open.Domain.Common;

namespace Open.Domain.Product
{
    public sealed class MedicineObject : UniqueObject<MedicineDbRecord>
    {
        private readonly List<EffectObject> effectsInMedicine;

        public MedicineObject(MedicineDbRecord r) : base(r ?? new MedicineDbRecord())
        {
            effectsInMedicine = new List<EffectObject>();
        }

        public IReadOnlyList<EffectObject> EffectsInMedicines =>
            effectsInMedicine.AsReadOnly();

        public void EffectsInMedicine(EffectObject effectObject)
        {
            if (effectObject is null) return;
            if (effectObject.DbRecord.ID == Constants.Unspecified) return;
            if (effectsInMedicine.Find(x => x.DbRecord.ID == effectObject.DbRecord.ID) != null)
                return;
            effectsInMedicine.Add(effectObject);
        }
    }
}