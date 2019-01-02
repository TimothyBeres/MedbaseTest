using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Common;
using Open.Data.Product;

namespace Open.Data.Representor
{
    public class MedicineRepresentorDbRecord : TemporalDbRecord
    {
        private string medicineId;
        private string representorId;

        public string MedicineID
        {
            get => getString(ref medicineId);
            set => medicineId = value;
        }

        public string RepresentorID
        {
            get => getString(ref representorId);
            set => representorId = value;
        }

        public virtual RepresentorDbRecord Representor { get; set; }

        public virtual MedicineDbRecord Medicine { get; set; }
    }
}
