using System.Threading.Tasks;
using Open.Core;
using Open.Data.Process;

namespace Open.Domain.Process
{
    public interface ISchemeObjectsRepository : IObjectsRepository<SchemeObject, SchemeDbRecord>
    {
        Task LoadSchemes(DosageObject dosage);
    }
}