using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class ActualIntencive
    {
        public int IdactualIntencive { get; set; }
        public int? ActualIntencive1 { get; set; }
        public DateTime? Date { get; set; }
        public string IdUser { get; set; }

        public virtual Aspnetusers IdUserNavigation { get; set; }
    }
}
