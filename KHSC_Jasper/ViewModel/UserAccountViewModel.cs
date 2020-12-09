using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KHSC_Jasper.ViewModel
{
    public class UserAccountViewModel
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
