using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Open.Facade.Common;
using Open.Facade.Product;

namespace Open.Facade.Person
{
    public class PersonViewModel : UniqueEntityViewModel
    {
        private string id_code;
        private string first_name;
        private string last_name;

        [Required]
        [DisplayName("ID Code")]
        public string IDCode
        {
            get => getString(ref id_code);
            set => id_code = value;
        }

        [Required]
        [DisplayName("First Name")]
        public string FirstName
        {
            get => getString(ref first_name);
            set => first_name = value;
        }

        [Required]
        [DisplayName("Last Name")]
        public string LastName
        {
            get => getString(ref last_name);
            set => last_name = value;
        }

        [DisplayName("Suggested medicines")]
        public List<MedicineViewModel> MedicinesInUse { get; } = new List<MedicineViewModel>();
    }
}