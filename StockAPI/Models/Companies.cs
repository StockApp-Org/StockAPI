﻿using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class Companies
    {
        public Companies()
        {
            CompanyStock = new HashSet<CompanyStock>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int IndustryId { get; set; }

        public virtual Industry Industry { get; set; }
        public virtual ICollection<CompanyStock> CompanyStock { get; set; }
    }
}
