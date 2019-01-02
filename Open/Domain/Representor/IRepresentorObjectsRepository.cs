using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Representor;

namespace Open.Domain.Representor
{
    public interface IRepresentorObjectsRepository : IObjectsRepository<RepresentorObject, RepresentorDbRecord>
    {
    }
}
