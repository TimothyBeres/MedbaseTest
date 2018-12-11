using Open.Aids;
using Open.Core;
using Open.Data.Common;
using Open.Data.Person;
using Open.Data.Product;

namespace Open.Data.Process
{
    public class DosageDbRecord : UniqueDbRecord
    {
        private string typeOfTreatment;
        private string personId;
        private string medicineId;

        public TypeOfTreatment TypeOfTreatment { get; set; }

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
    }
}