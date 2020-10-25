using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class RequestInformation
    {
        public int IdrequestInformation { get; set; }
        public int? SenderId { get; set; }
        public int? RecieverId { get; set; }
        public string Notes { get; set; }
        public int? FileId { get; set; }
        public int? TaskId { get; set; }

        public virtual File File { get; set; }
        public virtual Task Task { get; set; }
    }
}
