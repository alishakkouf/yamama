using System;
using System.Collections.Generic;

namespace Yamama
{
    public partial class ExpectedNeeds
    {
        public int IdexpectedNeeds { get; set; }
        public int? ExpectedQuantity { get; set; }
        public DateTime? Date { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
