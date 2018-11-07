using Open.Data.Common;
using Open.Data.Product;

namespace Open.Data.Person
{
    public class PersonMedicineDbRecord : TemporalDbRecord
    {
        private string personId;
        private string medicineId;
        private bool suitableForPerson = false;

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

        public bool SuitableForPerson
        {
            get => getBool(ref suitableForPerson);
            set => suitableForPerson = value;
        }


        public virtual PersonDbRecord Person { get; set; }

        public virtual MedicineDbRecord Medicine { get; set; }
    }
}