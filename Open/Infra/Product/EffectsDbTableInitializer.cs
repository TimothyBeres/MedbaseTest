using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Effect;

namespace Open.Infra.Product
{
    public static class EffectsDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Effects.Any()) return;
            initEffects(c);
            c.SaveChanges();
        }

        private static List<string> initEffects(SentryDbContext c)
        {
            var l = new List<string>
            {
                add(c, new EffectDbRecord
                {
                    Name = "morfiin"
                })
            };
            return l;
        }

        private static string add(SentryDbContext c, EffectDbRecord effect)
        {
            effect.ID = Guid.NewGuid().ToString();
            c.Effects.Add(effect);
            return effect.ID;
        }
    }
}