using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.Repository
{
   public interface IEmailSender
    {
        Task<int> SendEmailAsync(string from_email ,string password, string to_email, string subject, string message , string attachement);
    }
}
