using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open.Core
{
    public static class RoleExtensions
    {
        public static string GetRoleName(UserRoles role)
        {
            return role.ToString();
        }
        public static string GetRoleName(object role)
        {
            return role.ToString();
        }
    }
}
