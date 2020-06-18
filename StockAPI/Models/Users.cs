﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using StockAPI.Models.Views;

namespace StockAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            UserAddress = new HashSet<UserAddress>();
            UserShares = new HashSet<UserShares>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PersonNr { get; set; }
        public string OrgNr { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string ImgUrl { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<UserAddress> UserAddress { get; set; }
        public virtual ICollection<UserShares> UserShares { get; set; }
    }
}