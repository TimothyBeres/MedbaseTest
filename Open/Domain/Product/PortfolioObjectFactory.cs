using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public static class PortfolioObjectFactory
    {
        public static PortfolioObject Create(MedicineObject medicine, string userId,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var o = new PortfolioDbRecord
            {
                UserID = userId,
                Medicine = medicine?.DbRecord ?? new MedicineDbRecord(),
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.MedicineID = o.Medicine.ID;
            return new PortfolioObject(o);
        }
    }
}
