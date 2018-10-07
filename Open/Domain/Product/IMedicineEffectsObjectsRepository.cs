using System.Threading.Tasks;
using Open.Core;

namespace Open.Domain.Product
{
    public interface IMedicineEffectsObjectsRepository : ICrudRepository<MedicineEffectsObject>
    {
        Task LoadEffects(MedicineObject medicine);
        Task LoadMedicines(EffectObject effect);
        Task<MedicineEffectsObject> GetObject(string pro, string cat);
    }
}