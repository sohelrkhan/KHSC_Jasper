using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class UserAccounts
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int UserRole { get; set; }
    }
}
