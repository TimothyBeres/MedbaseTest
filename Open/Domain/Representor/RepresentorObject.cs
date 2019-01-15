using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Product;
using Open.Data.Representor;
using Open.Domain.Common;
using Open.Domain.Product;

namespace Open.Domain.Representor
{
    public sealed class RepresentorObject : UniqueObject<RepresentorDbRecord>
    {
        private readonly List<MedicineObject> representedMedicines;

        public RepresentorObject(RepresentorDbRecord r) : base(r ?? new RepresentorDbRecord())
        {
            representedMedicines = new List<MedicineObject>();
        }

        public IReadOnlyList<MedicineObject> RepresentedMedicines =>
            representedMedicines.AsReadOnly();

        public void RepresentedMedicine(MedicineObject medicineObject)
        {
            if (medicineObject is null) return;
            if (medicineObject.DbRecord.ID == Constants.Unspecified) return;
            if (representedMedicines.Find(x => x.DbRecord.ID == medicineObject.DbRecord.ID) != null)
                return;
            representedMedicines.Add(medicineObject);
        }
    }
}
