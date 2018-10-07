using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Common;
using Open.Facade.Money;

namespace Open.Facade.Product
{
    public class EffectViewModel : UniqueEntityViewModel
    {
        private string name;

        [Required]
        [DisplayName("Product Name")]
        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }

        [DisplayName("Used in Medicines")]
        public List<MedicineViewModel> UsedInMedicines { get; } = new List<MedicineViewModel>();
    }
}