using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Open.Facade.Common;
using Open.Facade.Product;
using Open.Core;
using Open.Facade.Process;

namespace Open.Facade.Person
{
    public class PersonViewModel : UniqueEntityViewModel
    {
        private string id_code;
        private string first_name;
        private string last_name;
        private string address;
        private string email;
        private string phone_number;
        private string nameError = "Nimi võib sisaldada ainult tähti!";

        [Required(ErrorMessage = Constants.FieldRequired)]
        [DisplayName("Isikukood")]
        [RegularExpression(@"^\d+$", ErrorMessage = Constants.IdDigitsError)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = Constants.IdLengthError)]
        public string IDCode
        {
            get => getString(ref id_code);
            set => id_code = value;
        }

        [Required(ErrorMessage = Constants.FieldRequired)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = Constants.NameError)]
        [DisplayName("Eesnimi")]
        public string FirstName
        {
            get => getString(ref first_name);
            set => first_name = value;
        }

        [Required(ErrorMessage = Constants.FieldRequired)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = Constants.NameError)]
        [DisplayName("Perekonnanimi")]
        public string LastName
        {
            get => getString(ref last_name);
            set => last_name = value;
        }

        [DisplayName("Aadress")]
        public string Address
        {
            get => getString(ref address);
            set => address = value;
        }

        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }

        [Required]
        [DisplayName("Telefon")]
        [RegularExpression(@"^\d+$", ErrorMessage = Constants.PhoneNumberDigitsError)]
        public string PhoneNumber
        {
            get => getString(ref phone_number);
            set => phone_number = value;
        }

        [DisplayName("Ravimiinfo kättesaamine")]
        public GetMedicineInfo GetMedicineInfo { get; set; }

        [Required(ErrorMessage = Constants.FieldRequired)]
        [DataType(DataType.Date)]
        [DisplayName("Sünnikuupäev")]
        public override DateTime? ValidFrom { get; set; }
        [DisplayName("")]
        public string EmptyHeader { get; set; }
        [DisplayName("Soovitatud ravimid")]
        public List<MedicineViewModel> MedicinesInUse { get; } = new List<MedicineViewModel>();
        [DisplayName("Eelnevad soovitused")]
        public List<PersonInfoViewModel> SuggestionsMade { get; } = new List<PersonInfoViewModel>();
    }
}