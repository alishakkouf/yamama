using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class Factory
    {
        public Factory()
        {
            Visit = new HashSet<Visit>();
        }

        public int Idfactory { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ActivityNature { get; set; }
        public int? ProductId { get; set; }
        public decimal? CementPrice { get; set; }
        public int? TransporterId { get; set; }
        public string Notes { get; set; }
        public string InformationSource { get; set; }

        public virtual ICollection<Visit> Visit { get; set; }
    }
}
