using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Open.Core;
using Open.Data.Common;

namespace Open.Data.Person
{
    public class PersonDbRecord : UniqueDbRecord
    {
        private string id_code;
        private string first_name;
        private string last_name;
        private string address;
        private string email;
        private string phone_number;

        public string IDCode
        {
            get => getString(ref id_code);
            set => id_code = value;
        }

        public string FirstName
        {
            get => getString(ref first_name);
            set => first_name = value;
        }

        public string LastName
        {
            get => getString(ref last_name);
            set => last_name = value;
        }

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

        public string PhoneNumber
        {
            get => getString(ref phone_number);
            set => phone_number = value;
        }

        public GetMedicineInfo GetMedicineInfo { get; set; }
    }
}