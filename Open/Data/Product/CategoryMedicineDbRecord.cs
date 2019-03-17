using Open.Data.Common;

namespace Open.Data.Product
{
    public class CategoryMedicineDbRecord : TemporalDbRecord
    {
        private string categoryId;
        private string medicineId;

        public string MedicineID
        {
            get => getString(ref medicineId);
            set => medicineId = value;
        }

        public string CategoryID
        {
            get => getString(ref categoryId);
            set => categoryId = value;
        }

        public virtual CategoryDbRecord Category { get; set; }

        public virtual MedicineDbRecord Medicine { get; set; }
    }
}