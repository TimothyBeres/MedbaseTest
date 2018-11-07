using Open.Data.Person;
using Open.Data.Product;
using Open.Domain.Common;
using Open.Domain.Product;

namespace Open.Domain.Person
{
    public class PersonMedicineObject : TemporalObject<PersonMedicineDbRecord>
    {
        public readonly PersonObject Person;
        public readonly MedicineObject Medicine;

        public PersonMedicineObject(PersonMedicineDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.Person = DbRecord.Person ?? new PersonDbRecord();
            DbRecord.Medicine = DbRecord.Medicine ?? new MedicineDbRecord();
            Person = new PersonObject(DbRecord.Person);
            Medicine = new MedicineObject(DbRecord.Medicine);
        }
    }
}