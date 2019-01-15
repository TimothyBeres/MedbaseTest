using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Product;
using Open.Data.Representor;
using Open.Domain.Product;

namespace Open.Domain.Representor
{
    public static class MedicineRepresentorsObjectFactory
    {
        public static MedicineRepresentorsObject Create(RepresentorObject representor, MedicineObject medicine,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var o = new MedicineRepresentorDbRecord
            {
                Representor = representor?.DbRecord ?? new RepresentorDbRecord(),
                Medicine = medicine?.DbRecord ?? new MedicineDbRecord(),
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.RepresentorID = o.Representor.ID;
            o.MedicineID = o.Medicine.ID;
            return new MedicineRepresentorsObject(o);
        }
    }
}
