using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Open.Facade.Common;
using Open.Facade.Product;
using Open.Core;

namespace Open.Facade.Person
{
    public class PersonViewModel : UniqueEntityViewModel
    {
        private string id_code;
        private string first_name;
        private string last_name;
        public string nameError = "Nimi võib sisaldada ainult tähti!";

        [Required(ErrorMessage = Constants.FieldRequired)]
        [DisplayName("Isikukood")]
        [RegularExpression(@"^\d+$", ErrorMessage = Constants.IdDigitsError)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = Constants.IdLengthError)]
        public string IDCode
        {
            get => getString(ref id_code);
            set => id_code = value;
        }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage = Constants.NameError)]
        [DisplayName("Eesnimi")]
        public string FirstName
        {
            get => getString(ref first_name);
            set => first_name = value;
        }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = Constants.NameError)]
        [DisplayName("Perekonnanimi")]
        public string LastName
        {
            get => getString(ref last_name);
            set => last_name = value;
        }

        [DisplayName("Soovitatud ravimid")]
        public List<MedicineViewModel> MedicinesInUse { get; } = new List<MedicineViewModel>();
    }
}