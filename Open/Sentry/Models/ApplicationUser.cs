using Microsoft.AspNetCore.Identity;
using Open.Domain.User;

namespace Sentry1.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IIdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
