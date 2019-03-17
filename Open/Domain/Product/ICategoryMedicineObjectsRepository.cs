using Open.Core;
using System.Threading.Tasks;

namespace Open.Domain.Product
{
    public interface ICategoryMedicineObjectsRepository : ICrudRepository<CategoryMedicineObject>
    {
        Task LoadCategories(MedicineObject medicine);
        Task LoadMedicines(CategoryObject effect);
        Task<CategoryMedicineObject> GetObject(string cat, string med);
    }
}