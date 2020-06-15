﻿using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class CompanyStock
    {
        public CompanyStock()
        {
            UserShares = new HashSet<UserShares>();
        }

        public int Shares { get; set; }
        public decimal? SharePrice { get; set; }
        public int CompanyId { get; set; }
        public int ShareId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual ICollection<UserShares> UserShares { get; set; }
    }
}
