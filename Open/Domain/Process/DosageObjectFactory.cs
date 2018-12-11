using System;
using System.Net;
using Open.Core;
using Open.Data.Process;

namespace Open.Domain.Process
{
    public static class DosageObjectFactory
    {
        public static DosageObject Create(string id, TypeOfTreatment typeOfTreatment, string personId, string medicineId, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new DosageDbRecord
            {
                ID = id,
                TypeOfTreatment = typeOfTreatment,
                PersonID = personId,
                MedicineID = medicineId,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new DosageObject(o);
        }

        public static DosageObject Create(DosageDbRecord dbrecord)
        {
            return new DosageObject(dbrecord);
        }
        
    }
}