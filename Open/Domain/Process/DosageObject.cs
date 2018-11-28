using System.Collections.Generic;
using Open.Core;
using Open.Data.Process;
using Open.Domain.Common;

namespace Open.Domain.Process
{
    public sealed class DosageObject : UniqueObject<DosageDbRecord>
    {
        private readonly List<SchemeObject> schemesInUse;

        public DosageObject(DosageDbRecord r) : base(r ?? new DosageDbRecord())
        {
            schemesInUse = new List<SchemeObject>();
        }

        public IReadOnlyList<SchemeObject> SchemesInUse => schemesInUse.AsReadOnly();

        public void SchemeInUse(SchemeObject schemeObject)
        {
            if (schemeObject is null) return;
            if (schemeObject.DbRecord.ID == Constants.Unspecified) return;
            if (schemesInUse.Find(x => x.DbRecord.ID == schemeObject.DbRecord.ID) != null) return;
            schemesInUse.Add(schemeObject);
        }
    }
}