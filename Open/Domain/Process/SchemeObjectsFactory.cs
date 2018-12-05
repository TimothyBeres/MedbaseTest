using System;
using Open.Data.Process;

namespace Open.Domain.Process
{
    public static class SchemeObjectsFactory
    {
        public static SchemeObject Create(string id, string dosageId, string queueNr, string length, 
            string amount, string times, string timeOfDay, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new SchemeDbRecord()
            {
                ID = id,
                DosageId = dosageId,
                QueueNr = queueNr,
                Length = length,
                Amount = amount,
                Times = times,
                TimeOfDay = timeOfDay,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new SchemeObject(o);
        }

        public static SchemeObject Create(SchemeDbRecord dbrecord)
        {
            return new SchemeObject(dbrecord);
        }
    }
}