using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public static class CategoryObjectFactory
    {
        public static CategoryObject Create(string id, string userId, string categoryName, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new CategoryDbRecord
            {
                ID = id,
                UserID = userId,
                CategoryName = categoryName,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new CategoryObject(o);
        }
    }
}
