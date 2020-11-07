using System;
using System.Collections.Generic;
using Yamama.Models;

namespace Yamama
{
    public partial class CustomerSatisfactionReports
    {
        public CustomerSatisfactionReports()
        {
            LinkRQA = new HashSet<LinkRQA>();
        }

        public int IdcustomerSatisfactionReports { get; set; }
        public int? ProjectId { get; set; }
        public string Notes { get; set; }
        public double SatisfactionEvaluation { get; set; }
        public int? FactoryId { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<LinkRQA> LinkRQA { get; set; }
    }
}
