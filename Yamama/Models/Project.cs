using System;
using System.Collections.Generic;

namespace Yamama.Models
{
    public partial class Project
    {
        public Project()
        {
            Visit = new HashSet<Visit>();
        }

        public int Idproject { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public string Space { get; set; }
        public decimal? Cost { get; set; }
        public string Contractor { get; set; }
        public string Consultant { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public string InformationSource { get; set; }

        public virtual ICollection<Visit> Visit { get; set; }
    }
}
