using System.Collections.Generic;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Process;

namespace Open.Domain.Process
{
    public interface IDosageObjectsRepository : IObjectsRepository<DosageObject, DosageDbRecord>
    {
        Task<List<DosageObject>> GetAllDosages(string personId);
    }
}