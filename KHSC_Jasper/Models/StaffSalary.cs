using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class StaffSalary
    {
        public int SsId { get; set; }
        public int StaffId { get; set; }
        public string MonthName { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public StaffInfo StaffInfo { get; set; }
    }
}
