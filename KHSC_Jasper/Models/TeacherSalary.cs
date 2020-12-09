using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class TeacherSalary
    {
        public int TsId { get; set; }
        public int TeacherId { get; set; }
        public string MonthName { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public TeacherInfo Teacher { get; set; }
    }
}
