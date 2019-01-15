using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Representor;
using Open.Domain.Product;

namespace Open.Domain.Representor
{
    public static class RepresentorObjectFactory
    {
        public static RepresentorObject Create(string id, string name,string email, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new RepresentorDbRecord
            {
                ID = id,
                Name = name,
                Email = email,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new RepresentorObject(o);
        }
    }
}
