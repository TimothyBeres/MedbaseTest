using System;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public static class MedicineObjectFactory
    {
        public static MedicineObject Create(string id, string name, string atc_code, string form_of_injection, string strength,
            string manufacturer, string legal_status, string reimbursement, string spc, string pil, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new MedicineDbRecord
            {
                ID = id,
                Name = name,
                AtcCode = atc_code,
                FormOfInjection = form_of_injection,
                Strength = strength,
                Manufacturer = manufacturer,
                LegalStatus = legal_status,
                Reimbursement = reimbursement,
                Spc = spc,
                Pil = pil,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new MedicineObject(o);
        }
    }
}