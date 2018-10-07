using System.Collections.Generic;
using Open.Core;
using Open.Data.Effect;
using Open.Domain.Common;

namespace Open.Domain.Product
{
    public sealed class EffectObject : UniqueObject<EffectDbRecord>
    {
        private readonly List<MedicineObject> usedInMedicines;

        public EffectObject(EffectDbRecord r) : base(r ?? new EffectDbRecord())
        {
            usedInMedicines = new List<MedicineObject>();
        }

        public IReadOnlyList<MedicineObject> UsesInMedicines =>
            usedInMedicines.AsReadOnly();

        public void UsedInMedicines(MedicineObject medicineObject)
        {
            if (medicineObject is null) return;
            if (medicineObject.DbRecord.ID == Constants.Unspecified) return;
            if (usedInMedicines.Find(x => x.DbRecord.ID == medicineObject.DbRecord.ID) != null)
                return;
            usedInMedicines.Add(medicineObject);
        }
    }
}