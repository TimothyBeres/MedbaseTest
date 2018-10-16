using Open.Core;
using Open.Data.Person;

namespace Open.Domain.Person
{
    public interface IPersonObjectsRepository : IObjectsRepository<PersonObject, PersonDbRecord>
    {

    }
}