using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Common;
using Open.Facade.Product;

namespace Open.Facade.Process
{
    public class SuggestionViewModel : UniqueEntityViewModel
    {
        private string medicineId;
        private string typeOfTreatment;
        private string length;
        private string amount;
        private string times;
        private string timeOfDay;
        private MedicineViewModel usedMedicine;

        [Required]
        public string MedicineID
        {
            get => getString(ref medicineId);
            set => medicineId = value;
        }
        [Required]
        [DisplayName("Ravi tüüp")]
        public string TypeOfTreatment
        {
            get => getString(ref typeOfTreatment);
            set => typeOfTreatment = value;
        }
        [Required]
        [DisplayName("Ravikuuri pikkus")]
        public string Length
        {
            get => getString(ref length);
            set => length = value;
        }
        [Required]
        [DisplayName("Annustamise kogus")]
        public string Amount
        {
            get => getString(ref amount);
            set => amount = value;
        }
        [Required]
        [DisplayName("Kordi võtta")]
        public string Times
        {
            get => getString(ref times);
            set => times = value;
        }
        [Required]
        [DisplayName("Millal?")]
        public string TimeOfDay
        {
            get => getString(ref timeOfDay);
            set => timeOfDay = value;
        }
        [DisplayName("Ravim")]
        public MedicineViewModel UsedMedicine
        {
            get { return usedMedicine; }
            set { usedMedicine = value; }
        }
    }
}