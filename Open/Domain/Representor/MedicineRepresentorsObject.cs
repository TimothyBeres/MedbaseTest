using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Product;
using Open.Data.Representor;
using Open.Domain.Common;
using Open.Domain.Product;

namespace Open.Domain.Representor
{
    public class MedicineRepresentorsObject : TemporalObject<MedicineRepresentorDbRecord>
    {
        public readonly RepresentorObject Representor;
        public readonly MedicineObject Medicine;

        public MedicineRepresentorsObject(MedicineRepresentorDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.Representor = DbRecord.Representor ?? new RepresentorDbRecord();
            DbRecord.Medicine = DbRecord.Medicine ?? new MedicineDbRecord();
            Representor = new RepresentorObject(DbRecord.Representor);
            Medicine = new MedicineObject(DbRecord.Medicine);
        }
    }
}
