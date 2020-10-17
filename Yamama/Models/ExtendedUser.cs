using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.Models
{
    public class ExtendedUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
