using Open.Core;
using Open.Data.Product;
using Open.Domain.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Infra.Product
{
    public class CategoryObjectsRepository : ObjectsRepository<CategoryObject, CategoryDbRecord>,
        ICategoryObjectsRepository
    {
        public CategoryObjectsRepository(SentryDbContext c) : base(c?.Categories, c) { }

        protected internal override CategoryObject createObject(CategoryDbRecord r)
        {
            return new CategoryObject(r);
        }

        protected internal override PaginatedList<CategoryObject> createList(
            List<CategoryDbRecord> l, RepositoryPage p)
        {
            return new CategoryObjectsList(l, p);
        }
        public async Task<List<CategoryObject>> GetCategories(string userId)
        {
            var allCategories = await GetObjectsList();
            var categories = allCategories.Where(x => x.DbRecord.UserID == userId).ToList();
            return categories;

        }
    }
}