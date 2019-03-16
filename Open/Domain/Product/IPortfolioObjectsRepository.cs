using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;

namespace Open.Domain.Product
{
    public interface IPortfolioObjectsRepository : ICrudRepository<PortfolioObject>
    {
        Task<List<MedicineObject>> GetMedicines(string userId);
        Task<PortfolioObject> GetObject(string medicineId, string userId);
    }
}
