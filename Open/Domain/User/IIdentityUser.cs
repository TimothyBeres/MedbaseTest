using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open.Domain.User
{
    public interface IIdentityUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
