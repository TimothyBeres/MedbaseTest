using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Core
{
    public interface IObjectsRepository<TObject, TRecord> :
        IPaginatedRepository<TObject, TRecord>,
        ICrudRepository<TObject>
    {
        bool IsInitialized();
    }
}
