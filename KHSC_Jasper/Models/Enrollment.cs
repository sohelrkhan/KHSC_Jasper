using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class Enrollment
    {


        public int EtId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int Year { get; set; }

        public ClassInfo Class { get; set; }
        public SectionInfo Section { get; set; }
        public StudentInfo Student { get; set; }
        public SubjectInfo Subject { get; set; }
        public TeacherInfo Teacher { get; set; }
    }
}
