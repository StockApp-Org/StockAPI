using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Models.Views
{
    public class UserShareView
    {
        public int ShareId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string IndustryName { get; set; }
        public int ShareCount { get; set; }
        public decimal NetWorth { get; set; }
        public decimal SharePercent { get; set; }
    }
}
