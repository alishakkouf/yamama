using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class ExpectedIntencive
    {
        public int IdexpectedIntencive { get; set; }
        public double? ExpectedMoney { get; set; }
        public DateTime? Date { get; set; }
        public string UserId { get; set; }

        public virtual Aspnetusers User { get; set; }
    }
}
