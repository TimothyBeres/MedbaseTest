using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Common;

namespace Open.Data.Representor
{
    public class RepresentorDbRecord : UniqueDbRecord
    {
        private string name;
        private string email;

        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }

        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }
    }
}
