using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class Industry
    {
        public Industry()
        {
            Companies = new HashSet<Companies>();
        }

        public int IndustryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
    }
}
