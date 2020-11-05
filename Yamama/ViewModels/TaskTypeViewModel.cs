using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;

namespace Yamama.ViewModels
{
    public class TaskTypeViewModel
    {
        public Visit visit { get; set; }
        public Models.Task task { get; set; }
        public Alert alert { get; set; }
        public RequestInformation reqInfo { get; set; }
        //public Photo photo { get; set; }
        //public File file { get; set; }

        //public Notification notification { get; set; }

    }
}
