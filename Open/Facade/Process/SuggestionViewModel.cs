using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;
using Open.Facade.Common;
using Open.Facade.Product;

namespace Open.Facade.Process
{
    public class SuggestionViewModel : UniqueEntityViewModel
    {
        private string medicineId;
        private string length;
        private string amount;
        private string times;
        private string timeOfDay;
        [Required]
        public string MedicineID
        {
            get => getString(ref medicineId);
            set => medicineId = value;
        }
        [Required]
        [DisplayName("Ravi tüüp")]
        public TypeOfTreatment TypeOfTreatment { get; set; }
        [DisplayName("Ravikuuri pikkus(päevades)")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Lahter võib sisaldada ainult numbreid")]
        public string Length
        {
            get => getString(ref length, "");
            set => length = value;
        }
        [DisplayName("Annustamise kogus")]
        public string Amount
        {
            get => getString(ref amount, "");
            set => amount = value;
        }
        [DisplayName("Kordi võtta")]
        public string Times
        {
            get => getString(ref times, "");
            set => times = value;
        }
        [DisplayName("Millal?")]
        public string TimeOfDay
        {
            get => getString(ref timeOfDay, "");
            set => timeOfDay = value;
        }
        [DisplayName("Ravim")]
        public MedicineViewModel UsedMedicine { get; set; }
    }
}