using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class Companies
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int IndustryId { get; set; }

        public virtual Industry Industry { get; set; }
    }
}
