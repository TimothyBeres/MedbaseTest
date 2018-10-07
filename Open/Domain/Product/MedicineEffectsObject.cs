using Open.Data.Effect;
using Open.Domain.Common;

namespace Open.Domain.Product
{
    public class MedicineEffectsObject : TemporalObject<MedicineEffectsDbRecord>
    {
        public readonly EffectObject Effect;
        public readonly MedicineObject Medicine;

        public MedicineEffectsObject(MedicineEffectsDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.Effect = DbRecord.Effect ?? new EffectDbRecord();
            DbRecord.Medicine = DbRecord.Medicine ?? new MedicineDbRecord();
            Effect = new EffectObject(DbRecord.Effect);
            Medicine = new MedicineObject(DbRecord.Medicine);
        }
    }
}