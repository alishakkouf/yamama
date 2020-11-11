using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Notification
    {
        public int Idnotification { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Message { get; set; }

        public virtual Aspnetusers Receiver { get; set; }
        public virtual Aspnetusers Sender { get; set; }
    }
}
