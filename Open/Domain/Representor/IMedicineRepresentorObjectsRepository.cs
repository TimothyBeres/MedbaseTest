using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;
using Open.Domain.Product;

namespace Open.Domain.Representor
{
    public interface IMedicineRepresentorsObjectsRepository : ICrudRepository<MedicineRepresentorsObject>
    {
        Task LoadRepresentors(MedicineObject medicine);
        Task LoadMedicines(RepresentorObject representor);
        Task<MedicineRepresentorsObject> GetObject(string rep, string med);
    }
}
