using System.Collections.Generic;
using Open.Core;
using Open.Data.Location;

namespace Open.Domain.Location
{
    public sealed class GeographicAddressObject : AddressObject<GeographicAddressDbRecord>
    {
        public readonly CountryObject Country;
        private readonly List<TelecomAddressObject> registeredDevices;

        public GeographicAddressObject(GeographicAddressDbRecord r) : base(
            r ?? new GeographicAddressDbRecord())
        {
            Country = new CountryObject(DbRecord.Country);
            registeredDevices = new List<TelecomAddressObject>();
        }

        public IReadOnlyList<TelecomAddressObject> RegisteredTelecomDevices =>
            registeredDevices.AsReadOnly();

        public void RegisteredTelecomDevice(TelecomAddressObject adr)
        {
            if (adr is null) return;
            if (adr.DbRecord.ID == Constants.Unspecified) return;
            if (registeredDevices.Find(
                x => x.DbRecord.ID == adr.DbRecord.ID) != null)
                return;
            registeredDevices.Add(adr);
        }
    }
}