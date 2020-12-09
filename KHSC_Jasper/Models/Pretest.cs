using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class Pretest
    {
        public int PretesetId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int ExamId { get; set; }
        public int Sub { get; set; }
        public int Obj { get; set; }
        public int Attendance { get; set; }
        public int Practical { get; set; }

        public ExamInfo Exam { get; set; }
        public StudentInfo Student { get; set; }
        public SubjectInfo Subject { get; set; }
        public TeacherInfo Teacher { get; set; }
    }
}
