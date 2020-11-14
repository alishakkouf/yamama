using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string ConfirmPass { get; set; }
    }
}
