using Open.Data.Common;

namespace Open.Data.Product
{
    public class MedicineEffectsDbRecord : TemporalDbRecord
    {
        private string medicineId;
        private string effectId;

        public string MedicineID
        {
            get => getString(ref medicineId);
            set => medicineId = value;
        }

        public string EffectID
        {
            get => getString(ref effectId);
            set => effectId = value;
        }

        public virtual EffectDbRecord Effect { get; set; }

        public virtual MedicineDbRecord Medicine { get; set; }
    }
}