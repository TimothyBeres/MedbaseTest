using Open.Data.Common;

namespace Open.Data.Product
{
    public class MedicineDbRecord : UniqueDbRecord
    {
        private string name;
        private string atc_code;
        private string form_of_injection;
        private string strength;
        private string manufacturer;
        private string legal_status;
        private string reimbursed;
        private string spc;
        private string pil;


        public string AtcCode
        {
            get => getString(ref atc_code);
            set => atc_code = value;
        }

        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }
        public string FormOfInjection
        {
            get => getString(ref form_of_injection);
            set => form_of_injection = value;
        }
        public string Strength
        {
            get => getString(ref strength);
            set => strength = value;
        }
        public string Manufacturer
        {
            get => getString(ref manufacturer);
            set => manufacturer = value;
        }
        public string LegalStatus
        {
            get => getString(ref legal_status);
            set => legal_status = value;
        }
        public string Spc
        {
            get => getString(ref spc);
            set => spc = value;
        }
        public string Pil
        {
            get => getString(ref pil);
            set => pil = value;
        }

        public string Reimbursement
        {
            get => getString(ref reimbursed);
            set => reimbursed = value;
        }
    }
}