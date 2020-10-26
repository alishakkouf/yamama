using Microsoft.AspNetCore.Identity;

namespace Yamama
{
    public class ExtendedUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}