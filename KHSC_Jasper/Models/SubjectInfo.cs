using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class SubjectInfo
    {
        public SubjectInfo()
        {
            Enrollment = new HashSet<Enrollment>();
            FinalYearResult = new HashSet<FinalYearResult>();
            HalfYearResult = new HashSet<HalfYearResult>();
            Pretest = new HashSet<Pretest>();
            TeacherInfo = new HashSet<TeacherInfo>();
            Test = new HashSet<Test>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int GroupId { get; set; }
        public int ClassId { get; set; }

        public ClassInfo Class { get; set; }
        public GroupInfo Group { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
        public ICollection<FinalYearResult> FinalYearResult { get; set; }
        public ICollection<HalfYearResult> HalfYearResult { get; set; }
        public ICollection<Pretest> Pretest { get; set; }
        public ICollection<TeacherInfo> TeacherInfo { get; set; }
        public ICollection<Test> Test { get; set; }
    }
}
