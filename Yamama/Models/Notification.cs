using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Notification
    {
        public int Idnotification { get; set; }
        public int? SenderId { get; set; }
        public int? RecieverId { get; set; }
        public string Message { get; set; }

        public virtual User Reciever { get; set; }
        public virtual User Sender { get; set; }
    }
}
