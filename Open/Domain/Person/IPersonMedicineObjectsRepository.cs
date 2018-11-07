using System.Threading.Tasks;
using Open.Core;
using Open.Domain.Product;

namespace Open.Domain.Person
{
    public interface IPersonMedicineObjectsRepository : ICrudRepository<PersonMedicineObject>
    {
        //Task LoadPersons(MedicineObject medicine);
        Task LoadMedicines(PersonObject persons);
        Task<PersonMedicineObject> GetObject(string med, string per);
    }
}