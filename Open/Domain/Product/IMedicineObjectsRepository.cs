using System.Threading.Tasks;
using Open.Core;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public interface IMedicineObjectsRepository : IObjectsRepository<MedicineObject, MedicineDbRecord>
    {
        Task<MedicineObject> GetMedicine(string name, string injection, string strength);
    }
}