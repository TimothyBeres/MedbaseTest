using Open.Data.Common;
using Open.Data.Person;
using Open.Data.Product;

namespace Open.Data.Process
{
    public class DosageDbRecord : UniqueDbRecord
    {
        private string type_of_treatment;
        private string personMedicine_id;

        public string TypeOfTreatment
        {
            get => getString(ref type_of_treatment);
            set => type_of_treatment = value;
        }

        public string PersonMedicineId
        {
            get => getString(ref personMedicine_id);
            set => personMedicine_id = value;
        }
        public virtual PersonDbRecord Person { get; set; }
        public virtual MedicineDbRecord Medicine { get; set; }
        public virtual PersonMedicineDbRecord PersonMedicine { get; set; }
    }
}