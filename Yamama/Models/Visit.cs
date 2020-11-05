using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Visit
    {
        public int Idvisit { get; set; }
        public int? UserId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProjectId { get; set; }
        public int? TaskId { get; set; }
        public int? Gifts { get; set; }
        public string Notes { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Project Project { get; set; }
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
