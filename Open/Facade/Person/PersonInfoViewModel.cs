using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Common;

namespace Open.Facade.Person
{
    public class PersonInfoViewModel : UniqueEntityViewModel
    {
        private string medicineName;
        private string formOfInjection;
        private string suitable;
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
        public string Suitable
        {
            get => getString(ref suitable);
            set => suitable = value;
        }
    }
}