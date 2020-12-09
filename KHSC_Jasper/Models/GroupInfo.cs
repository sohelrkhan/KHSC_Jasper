using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class GroupInfo
    {
        public GroupInfo()
        {
            StudentInfo = new HashSet<StudentInfo>();
            SubjectInfo = new HashSet<SubjectInfo>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SectionId { get; set; }

        public SectionInfo Section { get; set; }
        public ICollection<StudentInfo> StudentInfo { get; set; }
        public ICollection<SubjectInfo> SubjectInfo { get; set; }
    }
}
