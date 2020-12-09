using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class AdmissionForm
    {
        public int AfId { get; set; }
        public int AdmitCardNo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int CollegeRoll { get; set; }
        public string Section { get; set; }
        public string ElectiveSubject1 { get; set; }
        public string ElectiveSubject2 { get; set; }
        public string ElectiveSubject3 { get; set; }
        public string FourthSubject { get; set; }
        public string NameOftheStudent { get; set; }
        public string DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodGroup { get; set; }
        public string FathersName { get; set; }
        public string FathersEducationalQualification { get; set; }
        public string FathersOccupation { get; set; }
        public string FathersMobileNo { get; set; }
        public int FatherNid { get; set; }
        public string MothersName { get; set; }
        public string MothersEducationalQualification { get; set; }
        public string MothersOccupation { get; set; }
        public string MothersMobileNo { get; set; }
        public int MotherNid { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NameOfGuardian { get; set; }
        public string GuardianAddress { get; set; }
        public string GuardianMobileNo { get; set; }
        public string FathersTotalAnnualincome { get; set; }
        public string JscyearOfTheExam { get; set; }
        public string JscnameOfTheBoard { get; set; }
        public string JscroolNo { get; set; }
        public string JscregistrationNo { get; set; }
        public string Jscsession { get; set; }
        public string JscGpa { get; set; }
        public string JscnameOfInstitution { get; set; }
        public string SscyearOfTheExam { get; set; }
        public string SscnameOfTheBoard { get; set; }
        public string SscroolNo { get; set; }
        public string SscregistrationNo { get; set; }
        public string Sscsession { get; set; }
        public string SscGpa { get; set; }
        public string SscnameOfInstitution { get; set; }
        public string NameOfTheLastSchoolorCollegeAttended { get; set; }
    }
}
