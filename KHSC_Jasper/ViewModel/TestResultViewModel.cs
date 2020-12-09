using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KHSC_Jasper.ViewModel
{
    public class TestResultViewModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Obj { get; set; }
        public int Sub { get; set; }
        public int Practical { get; set; }
        public int Attendance { get; set; }
    }
}
