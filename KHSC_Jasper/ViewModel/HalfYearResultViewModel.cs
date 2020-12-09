using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KHSC_Jasper.ViewModel
{
    public class HalfYearResultViewModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Ct1 { get; set; }
        public int Obj { get; set; }
        public int Sub { get; set; }
        public int Practical { get; set; }
        public int Attendence { get; set; }
    }
}
