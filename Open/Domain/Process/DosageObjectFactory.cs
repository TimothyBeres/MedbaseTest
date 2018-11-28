using System.Net;
using Open.Data.Process;

namespace Open.Domain.Process
{
    public static class DosageObjectFactory
    {
        public static DosageObject Create(string id, string typeOfTreatment, string key)
        {
            var o = new DosageDbRecord {ID = id, TypeOfTreatment = typeOfTreatment, PersonMedicineId = key};
            return new DosageObject(o);
        }

        public static DosageObject Create(DosageDbRecord dbrecord)
        {
            return new DosageObject(dbrecord);
        }
        
    }
}