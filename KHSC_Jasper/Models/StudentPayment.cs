using System;
using System.Collections.Generic;

namespace KHSC_Jasper.Models
{
    public partial class StudentPayment
    {
        public int SpId { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int? FormFee { get; set; }
        public int? AdmissionFee { get; set; }
        public int? ReAdmissionFee { get; set; }
        public int? TcCharge { get; set; }
        public int? SeasonCharge { get; set; }
        public int? CertificateFee { get; set; }
        public int? TestimonialFee { get; set; }
        public string WhichMonthFee { get; set; }
        public int? MonthFeeAmount { get; set; }
        public int? Ct1Fee { get; set; }
        public int? Ct2Fee { get; set; }
        public int? HalfYearlyFee { get; set; }
        public int? FinalYearlyFee { get; set; }
        public int? WaterElectricityFee { get; set; }
        public int? Tex { get; set; }
        public int? DevlopmentFee { get; set; }
        public int? BuildingDevFee { get; set; }
        public int? LabFee { get; set; }
        public int? LibraryFee { get; set; }
        public int? ComputerFee { get; set; }
        public int? RegistrationFee { get; set; }
        public int? CautionMoney { get; set; }
        public int? Fine { get; set; }
        public int? ReportCardFee { get; set; }
        public int? AdmitCardFee { get; set; }
        public int? IdCardFee { get; set; }
        public int? FormFillUpEFf { get; set; }
        public int? FormFillUpJsc { get; set; }
        public int? FormFillUpSsc { get; set; }
        public int? FormFillUpHsc { get; set; }
        public int? ItFee { get; set; }
        public int? ScienceDevelopmentFee { get; set; }
        public int? CareFee { get; set; }
        public string OtherFeeName { get; set; }
        public int? OtherFeeAmount { get; set; }

        public StudentInfo Student { get; set; }
    }
}
