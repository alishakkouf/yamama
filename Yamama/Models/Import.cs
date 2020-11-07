using System;
using System.Collections.Generic;
using Yamama.Models;

namespace Yamama
{
    public partial class Import
    {
        public int IdImport { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }

        public virtual Product Product { get; set; }
    }
}
