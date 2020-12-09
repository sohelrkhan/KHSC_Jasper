using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class TeacherInfo
    {
        public TeacherInfo()
        {
            Enrollment = new HashSet<Enrollment>();
            FinalYearResult = new HashSet<FinalYearResult>();
            HalfYearResult = new HashSet<HalfYearResult>();
            Pretest = new HashSet<Pretest>();
            TeacherSalary = new HashSet<TeacherSalary>();
            Test = new HashSet<Test>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int SubjectId { get; set; }
        public string Email { get; set; }
        public int Cell { get; set; }
        public string Position { get; set; }

        public SubjectInfo Subject { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
        public ICollection<FinalYearResult> FinalYearResult { get; set; }
        public ICollection<HalfYearResult> HalfYearResult { get; set; }
        public ICollection<Pretest> Pretest { get; set; }
        public ICollection<TeacherSalary> TeacherSalary { get; set; }
        public ICollection<Test> Test { get; set; }
    }
}
