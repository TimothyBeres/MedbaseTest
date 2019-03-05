using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Product;
using Open.Domain.Common;

namespace Open.Domain.Product
{
    public class PortfolioObject : TemporalObject<PortfolioDbRecord>
    {
        public readonly MedicineObject Medicine;

        public PortfolioObject(PortfolioDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.Medicine = DbRecord.Medicine ?? new MedicineDbRecord();
            Medicine = new MedicineObject(DbRecord.Medicine);
        }
    }
}
