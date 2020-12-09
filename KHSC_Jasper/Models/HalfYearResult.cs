using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class HalfYearResult
    {
        public int Hy { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int ExamId { get; set; }
        public int Ct1 { get; set; }
        public int Sub { get; set; }
        public int Obj { get; set; }
        public int Practical { get; set; }
        public int Attendence { get; set; }

        public ExamInfo Exam { get; set; }
        public StudentInfo Student { get; set; }
        public SubjectInfo Subject { get; set; }
        public TeacherInfo Teacher { get; set; }
    }
}
