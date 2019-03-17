using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public interface ICategoryObjectsRepository : IObjectsRepository<CategoryObject, CategoryDbRecord>
    {
        Task<List<CategoryObject>> GetCategories(string userId);
    }
}
