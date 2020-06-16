using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Models.Views
{
    public class CompanyShareView
    {
        public int CompanyId { get; set; }
        public int IndustryId { get; set; }
        public string CompanyName { get; set; }
        public string IndustryName { get; set; }
        public int AvailableShares { get; set; }
        public decimal SharePrice { get; set; }
        public decimal NetWorth { get; set; }
    }
}
