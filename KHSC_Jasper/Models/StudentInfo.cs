using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class StudentInfo
    {

        public StudentInfo()
        {
            Enrollment = new HashSet<Enrollment>();
            FinalYearResult = new HashSet<FinalYearResult>();
            HalfYearResult = new HashSet<HalfYearResult>();
            Pretest = new HashSet<Pretest>();
            StudentPayment = new HashSet<StudentPayment>();
            Test = new HashSet<Test>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentRoll { get; set; }
        public int SectionId { get; set; }
        public int ClassId { get; set; }
        public int ShiftId { get; set; }
        public int GroupId { get; set; }
        public int Year { get; set; }

        public ClassInfo Class { get; set; }
        public GroupInfo Group { get; set; }
        public SectionInfo Section { get; set; }
        public ShiftInfo Shift { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
        public ICollection<FinalYearResult> FinalYearResult { get; set; }
        public ICollection<HalfYearResult> HalfYearResult { get; set; }
        public ICollection<Pretest> Pretest { get; set; }
        public ICollection<StudentPayment> StudentPayment { get; set; }
        public ICollection<Test> Test { get; set; }
    }
}
