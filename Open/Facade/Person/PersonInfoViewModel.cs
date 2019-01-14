using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;
using Open.Domain.Process;
using Open.Facade.Common;

namespace Open.Facade.Person
{
    public class PersonInfoViewModel : UniqueEntityViewModel
    {
        private string medicineName;
        private string formOfInjection;
        private string medicineId;
        private string dosageId;
        private string description;
        [Required]
        [DisplayName("Ravimi nimetus")]
        public string MedicineName
        {
            get => getString(ref medicineName);
            set => medicineName = value;
        }
        [Required]
        [DisplayName("Ravimi manustamine")]
        public string FormOfInjection
        {
            get => getString(ref formOfInjection);
            set => formOfInjection = value;
        }
        [Required]
        [DisplayName("Sobivus")]
        public Suitability Suitability { get; set; }
        public string MedicineID
        {
            get => getString(ref medicineId);
            set => medicineId = value;
        }
        public string DosageID
        {
            get => getString(ref dosageId);
            set => dosageId = value;
        }
        [DisplayName("Lisa märkmed")]
        public string Description
        {
            get => getString(ref description);
            set => description = value;
        }
        [DisplayName("")]
        public string EmptyHeader { get; set; }
    }
}