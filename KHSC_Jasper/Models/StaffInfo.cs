using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class StaffInfo
    {
        public int SsId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string WorkingSector { get; set; }
        public int Cell { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public StaffSalary Ss { get; set; }
    }
}
