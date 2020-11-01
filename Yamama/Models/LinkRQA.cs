using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class LinkRQA
    {
        public int IdlinkRQA { get; set; }
        public int? ReportId { get; set; }
        public int? QId { get; set; }
        public int? AnswerId { get; set; }

        public virtual Answers Answer { get; set; }
        public virtual Questions Q { get; set; }
        public virtual CustomerSatisfactionReports Report { get; set; }
    }
}
