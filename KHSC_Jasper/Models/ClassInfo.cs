using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class ClassInfo
    {
        public ClassInfo()
        {
            Enrollment = new HashSet<Enrollment>();
            SectionInfo = new HashSet<SectionInfo>();
            StudentInfo = new HashSet<StudentInfo>();
            SubjectInfo = new HashSet<SubjectInfo>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
        public ICollection<SectionInfo> SectionInfo { get; set; }
        public ICollection<StudentInfo> StudentInfo { get; set; }
        public ICollection<SubjectInfo> SubjectInfo { get; set; }
    }
}
