using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class CompanyStock
    {
        public int Shares { get; set; }
        public decimal? SharePrice { get; set; }
        public int CompanyId { get; set; }

        public virtual Companies Company { get; set; }
    }
}
