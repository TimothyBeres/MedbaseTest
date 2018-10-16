using System;
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
        [FieldConverter(ConverterKind.Date, "dd.MM.yyyy")]
        [FieldNullValue(typeof(DateTime), "1900-01-01")]
        private DateTime validFrom;

        [FieldOptional]
        [FieldConverter(ConverterKind.Date, "dd.MM.yyyy")]
        [FieldNullValue(typeof(DateTime), "1900-01-01")]
        private DateTime validTo;


        
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
        public DateTime ValidFrom
        {
            get { return validFrom; }
            set { validFrom = value; }
        }

        [FieldOptional]
        public DateTime ValidTo
        {
            get { return validTo; }
            set { validTo = value; }
        }
    }
}