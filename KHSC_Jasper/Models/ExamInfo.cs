using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class ExamInfo
    {
        public ExamInfo()
        {
            FinalYearResult = new HashSet<FinalYearResult>();
            HalfYearResult = new HashSet<HalfYearResult>();
            Pretest = new HashSet<Pretest>();
            Test = new HashSet<Test>();
        }

        public int ExamId { get; set; }
        public string ExamName { get; set; }

        public ICollection<FinalYearResult> FinalYearResult { get; set; }
        public ICollection<HalfYearResult> HalfYearResult { get; set; }
        public ICollection<Pretest> Pretest { get; set; }
        public ICollection<Test> Test { get; set; }
    }
}
