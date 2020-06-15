using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class UserShares
    {
        public int UserId { get; set; }
        public int ShareId { get; set; }
        public int? Count { get; set; }

        public virtual CompanyStock Share { get; set; }
        public virtual Users User { get; set; }
    }
}
