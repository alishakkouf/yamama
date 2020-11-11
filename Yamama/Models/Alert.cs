using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Alert
    {
        public int Idalert { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public string Notes { get; set; }
        public int? FileId { get; set; }
        public int? TaskId { get; set; }

        public virtual File File { get; set; }
        public virtual Task Task { get; set; }
    }
}
