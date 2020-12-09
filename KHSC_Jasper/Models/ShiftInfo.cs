using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class ShiftInfo
    {
        public ShiftInfo()
        {
            StudentInfo = new HashSet<StudentInfo>();
        }

        public int ShiftId { get; set; }
        public string ShiftName { get; set; }

        public ICollection<StudentInfo> StudentInfo { get; set; }
    }
}
