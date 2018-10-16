using System;
using Open.Data.Person;

namespace Open.Domain.Person
{
    public static class PersonObjectFactory
    {
        public static PersonObject Create(string id, string id_code, string first_name, string last_name, DateTime? validFrom = null,
            DateTime? validTo = null)
        {
            var o = new PersonDbRecord
            {
                ID = id,
                IDCode = id_code,
                FirstName = first_name,
                LastName = last_name,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new PersonObject(o);
        }
    }
}