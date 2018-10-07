using FileHelpers;

namespace Sentry1.Services
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    public class MedicineTemplate
    {
        [FieldOptional]
        private string atc;
        [FieldOptional]
        private string effects;
        [FieldOptional]
        private string name;
        [FieldOptional]
        private string formofinjection;
        [FieldOptional]
        private string strength;
        [FieldOptional]
        private string legalstatus;
        [FieldOptional]
        private string reimbursement;
        [FieldOptional]
        private string manufacturer;
        [FieldOptional]
        private string spc;
        [FieldOptional]
        private string pil;
        [FieldOptional]
        private string emptyness;

        [FieldOptional] private string emptyness2;


        [FieldOptional]
        public string AtcCode
        {
            get { return atc; }
            set { atc = value; }
        }
        [FieldOptional]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [FieldOptional]
        public string Effects
        {
            get { return effects; }
            set { effects = value; }
        }
        [FieldOptional]
        public string FormOfInjection
        {
            get { return formofinjection; }
            set { formofinjection = value; }
        }
        [FieldOptional]
        public string Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        [FieldOptional]
        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        [FieldOptional]
        public string LegalStatus
        {
            get { return legalstatus; }
            set { legalstatus = value; }
        }
        [FieldOptional]
        public string Spc
        {
            get { return spc; }
            set { spc = value; }
        }
        [FieldOptional]
        public string Pil
        {
            get { return pil; }
            set { pil = value; }
        }
        [FieldOptional]
        public string Reimbursement
        {
            get { return reimbursement; }
            set { reimbursement = value; }
        }
        [FieldOptional]
        public string Emptyness
        {
            get { return emptyness; }
            set { emptyness = value; }
        }

        [FieldOptional]
        public string Emptyness2
        {
            get { return emptyness2; }
            set { emptyness2 = value; }
        }
    }
}