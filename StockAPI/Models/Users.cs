using System;
using System.Collections.Generic;

namespace StockAPI.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PersonNr { get; set; }
        public string OrgNr { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string ImgUrl { get; set; }
    }
}
