using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.Services
{
    public class AuthMessageSMSSenderOptions
    {
       

        public string SID { get; set; }
        public string AuthToken { get; set; }
       
        public string SMSAccountFrom { get; set; }
    }
}
