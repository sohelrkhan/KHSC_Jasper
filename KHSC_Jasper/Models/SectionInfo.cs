using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class SectionInfo
    {
        public SectionInfo()
        {
            Enrollment = new HashSet<Enrollment>();
            GroupInfo = new HashSet<GroupInfo>();
            StudentInfo = new HashSet<StudentInfo>();
        }

        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int ClassId { get; set; }

        public ClassInfo Class { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
        public ICollection<GroupInfo> GroupInfo { get; set; }
        public ICollection<StudentInfo> StudentInfo { get; set; }
    }
}
