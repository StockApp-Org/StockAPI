using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class UserAddress
    {
        public int UserId { get; set; }
        public string AddressRow1 { get; set; }
        public string AddressRow2 { get; set; }
        public string AddressRow3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public virtual Users User { get; set; }
    }
}
