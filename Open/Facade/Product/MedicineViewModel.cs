using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Common;

namespace Open.Facade.Product
{
    public class MedicineViewModel : UniqueEntityViewModel
    {
        private string name;
        private string atc_code;
        private string form_of_injection;
        private string strength;
        private string manufacturer;
        private string legal_status;
        private string reimbursement;
        private string spc;
        private string pil;


        [Required]
        [DisplayName("Ravimi nimetus")]
        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }

        [Required]
        [DisplayName("ATC kood")]
        public string AtcCode
        {
            get => getString(ref atc_code);
            set => atc_code = value;
        }
        [Required]
        [DisplayName("Manustamisviis")]
        public string FormOfInjection
        {
            get => getString(ref form_of_injection);
            set => form_of_injection = value;
        }
        [Required]
        [DisplayName("Tugevus")]
        public string Strength
        {
            get => getString(ref strength);
            set => strength = value;
        }
        [Required]
        [DisplayName("Tootja")]
        public string Manufacturer
        {
            get => getString(ref manufacturer);
            set => manufacturer = value;
        }
        [Required]
        [DisplayName("Legaalne staatus")]
        public string LegalStatus
        {
            get => getString(ref legal_status);
            set => legal_status = value;
        }
        [Required]
        [DisplayName("Hüvitamine riigi poolt")]
        public string Reimbursement
        {
            get => getString(ref reimbursement);
            set => reimbursement = value;
        }
        [Required]
        [DisplayName("SPC")]
        public string Spc
        {
            get => getString(ref spc);
            set => spc = value;
        }
        [Required]
        [DisplayName("PIL")]
        public string Pil
        {
            get => getString(ref pil);
            set => pil = value;
        }
        [DisplayName("")]
        public string EmptyHeader { get; set; }
        [DisplayName("Toimeained ravimis")]
        public List<EffectViewModel> EffectsInMedicine { get; } = new List<EffectViewModel>();
    }
}