using Open.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Open.Data.Person;

namespace Open.Domain.Person
{
    public interface IPersonObjectsRepository : IObjectsRepository<PersonObject, PersonDbRecord>
    {
        Task<PersonObject> GetPersonByIDCode(string id_code);
    }
}