using System.Collections.Generic;
using Open.Core;
using Open.Data.Process;
using Open.Domain.Common;

namespace Open.Domain.Process
{
    public class SchemeObject : UniqueObject<SchemeDbRecord>
    {
        public SchemeObject(SchemeDbRecord r) : base(r ?? new SchemeDbRecord()) { }

    }
}