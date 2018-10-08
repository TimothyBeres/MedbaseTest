using System;
using Open.Data.Product;

namespace Open.Domain.Product
{
    public static class EffectObjectFactory
    {
        public static EffectObject Create(string id, string name, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new EffectDbRecord
            {
                ID = id,
                Name = name,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new EffectObject(o);
        }
    }
}