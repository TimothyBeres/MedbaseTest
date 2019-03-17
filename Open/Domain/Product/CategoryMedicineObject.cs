using Open.Data.Product;
using Open.Domain.Common;

namespace Open.Domain.Product
{
    public class CategoryMedicineObject : TemporalObject<CategoryMedicineDbRecord>
    {
        public readonly CategoryObject Category;
        public readonly MedicineObject Medicine;

        public CategoryMedicineObject(CategoryMedicineDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.Category = DbRecord.Category ?? new CategoryDbRecord();
            DbRecord.Medicine = DbRecord.Medicine ?? new MedicineDbRecord();
            Category = new CategoryObject(DbRecord.Category);
            Medicine = new MedicineObject(DbRecord.Medicine);
        }
    }
}