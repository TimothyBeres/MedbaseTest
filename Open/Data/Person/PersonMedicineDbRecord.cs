using Open.Aids;
using Open.Core;
using Open.Data.Common;
using Open.Data.Product;

namespace Open.Data.Person
{
    public class PersonMedicineDbRecord : TemporalDbRecord
    {
        private string personId;
        private string medicineId;

        public string PersonID
        {
            get => getString(ref personId);
            set => personId = value;
        }

        public string MedicineID
        {
            get => getString(ref medicineId);
            set => medicineId = value;
        }

        public Suitability Suitability { get; set; }


        public virtual PersonDbRecord Person { get; set; }

        public virtual MedicineDbRecord Medicine { get; set; }
    }
}