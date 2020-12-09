using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KHSC_Jasper.Models
{
    public partial class KHSCDBContext : DbContext
    {
        public virtual DbSet<AdmissionForm> AdmissionForm { get; set; }
        public virtual DbSet<ClassInfo> ClassInfo { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<ExamInfo> ExamInfo { get; set; }
        public virtual DbSet<FinalYearResult> FinalYearResult { get; set; }
        public virtual DbSet<GovernmentPayment> GovernmentPayment { get; set; }
        public virtual DbSet<GradeInfo> GradeInfo { get; set; }
        public virtual DbSet<GroupInfo> GroupInfo { get; set; }
        public virtual DbSet<HalfYearResult> HalfYearResult { get; set; }
        public virtual DbSet<OtherCostInfo> OtherCostInfo { get; set; }
        public virtual DbSet<Pretest> Pretest { get; set; }
        public virtual DbSet<SectionInfo> SectionInfo { get; set; }
        public virtual DbSet<ShiftInfo> ShiftInfo { get; set; }
        public virtual DbSet<StaffInfo> StaffInfo { get; set; }
        public virtual DbSet<StaffSalary> StaffSalary { get; set; }
        public virtual DbSet<StudentInfo> StudentInfo { get; set; }
        public virtual DbSet<StudentPayment> StudentPayment { get; set; }
        public virtual DbSet<SubjectInfo> SubjectInfo { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfo { get; set; }
        public virtual DbSet<TeacherSalary> TeacherSalary { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }

        public KHSCDBContext(DbContextOptions<KHSCDBContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmissionForm>(entity =>
            {
                entity.HasKey(e => e.AfId);

                entity.Property(e => e.AfId).HasColumnName("AF_id");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.BloodGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ElectiveSubject1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ElectiveSubject2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ElectiveSubject3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FatherNid).HasColumnName("Father_NID");

                entity.Property(e => e.FathersEducationalQualification)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FathersMobileNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FathersName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FathersOccupation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FathersTotalAnnualincome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FourthSubject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GuardianAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GuardianMobileNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Height)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JscGpa)
                    .IsRequired()
                    .HasColumnName("JSC_GPA")
                    .HasMaxLength(50);

                entity.Property(e => e.JscnameOfInstitution)
                    .IsRequired()
                    .HasColumnName("JSCNameOfInstitution")
                    .HasMaxLength(50);

                entity.Property(e => e.JscnameOfTheBoard)
                    .IsRequired()
                    .HasColumnName("JSCNameOfTheBoard")
                    .HasMaxLength(50);

                entity.Property(e => e.JscregistrationNo)
                    .IsRequired()
                    .HasColumnName("JSCRegistrationNo")
                    .HasMaxLength(50);

                entity.Property(e => e.JscroolNo)
                    .IsRequired()
                    .HasColumnName("JSCRoolNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Jscsession)
                    .IsRequired()
                    .HasColumnName("JSCSession")
                    .HasMaxLength(50);

                entity.Property(e => e.JscyearOfTheExam)
                    .IsRequired()
                    .HasColumnName("JSCYearOfTheExam")
                    .HasMaxLength(50);

                entity.Property(e => e.MotherNid).HasColumnName("Mother_NID");

                entity.Property(e => e.MothersEducationalQualification)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MothersMobileNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MothersName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MothersOccupation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameOfGuardian)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameOfTheLastSchoolorCollegeAttended)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameOftheStudent)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PermanentAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PresentAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Religion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SscGpa)
                    .IsRequired()
                    .HasColumnName("SSC_GPA")
                    .HasMaxLength(50);

                entity.Property(e => e.SscnameOfInstitution)
                    .IsRequired()
                    .HasColumnName("SSCNameOfInstitution")
                    .HasMaxLength(50);

                entity.Property(e => e.SscnameOfTheBoard)
                    .IsRequired()
                    .HasColumnName("SSCNameOfTheBoard")
                    .HasMaxLength(50);

                entity.Property(e => e.SscregistrationNo)
                    .IsRequired()
                    .HasColumnName("SSCRegistrationNo")
                    .HasMaxLength(50);

                entity.Property(e => e.SscroolNo)
                    .IsRequired()
                    .HasColumnName("SSCRoolNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Sscsession)
                    .IsRequired()
                    .HasColumnName("SSCSession")
                    .HasMaxLength(50);

                entity.Property(e => e.SscyearOfTheExam)
                    .IsRequired()
                    .HasColumnName("SSCYearOfTheExam")
                    .HasMaxLength(50);

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClassInfo>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.ToTable("class_info");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasColumnName("class_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.EtId);

                entity.ToTable("enrollment");

                entity.Property(e => e.EtId).HasColumnName("et_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_enrollment_class_info");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_enrollment_section_info");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_enrollment_student_info");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_enrollment_subject_info");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_enrollment_teacher_info");
            });

            modelBuilder.Entity<ExamInfo>(entity =>
            {
                entity.HasKey(e => e.ExamId);

                entity.ToTable("exam_info");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasColumnName("exam_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FinalYearResult>(entity =>
            {
                entity.HasKey(e => e.Fy);

                entity.ToTable("final_year_result");

                entity.Property(e => e.Fy).HasColumnName("fy");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.Ct2).HasColumnName("ct_2");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Obj).HasColumnName("obj");

                entity.Property(e => e.Practical).HasColumnName("practical");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Sub).HasColumnName("sub");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.FinalYearResult)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_final_year_result_exam_info");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.FinalYearResult)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_final_year_result_student_info");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.FinalYearResult)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_final_year_result_subject_info");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.FinalYearResult)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_final_year_result_teacher_info");
            });

            modelBuilder.Entity<GovernmentPayment>(entity =>
            {
                entity.HasKey(e => e.GpId);

                entity.ToTable("Government_payment");

                entity.Property(e => e.GpId).HasColumnName("GP_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.MonthName)
                    .IsRequired()
                    .HasColumnName("Month_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GradeInfo>(entity =>
            {
                entity.HasKey(e => e.GradeId);

                entity.ToTable("grade_info");

                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("grade")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GroupInfo>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("group_info");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.GroupInfo)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_group_info_section_info");
            });

            modelBuilder.Entity<HalfYearResult>(entity =>
            {
                entity.HasKey(e => e.Hy);

                entity.ToTable("half_year_result");

                entity.Property(e => e.Hy).HasColumnName("hy");

                entity.Property(e => e.Attendence).HasColumnName("attendence");

                entity.Property(e => e.Ct1).HasColumnName("ct_1");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Obj).HasColumnName("obj");

                entity.Property(e => e.Practical).HasColumnName("practical");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Sub).HasColumnName("sub");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.HalfYearResult)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_half_year_result_exam_info");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.HalfYearResult)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_half_year_result_student_info");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.HalfYearResult)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_half_year_result_subject_info");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.HalfYearResult)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_half_year_result_teacher_info");
            });

            modelBuilder.Entity<OtherCostInfo>(entity =>
            {
                entity.HasKey(e => e.OcId);

                entity.ToTable("Other_Cost_Info");

                entity.Property(e => e.OcId).HasColumnName("OC_id");

                entity.Property(e => e.AnyCostFee).HasColumnName("Any_cost_fee");

                entity.Property(e => e.AnyCostName).HasColumnName("Any cost_name");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ElectricityBillAmount).HasColumnName("Electricity_bill_amount");

                entity.Property(e => e.ElectricityBillMonthName)
                    .HasColumnName("electricity_bill_month_name")
                    .HasMaxLength(50);

                entity.Property(e => e.FunctionCost).HasColumnName("Function_cost");

                entity.Property(e => e.ItBill).HasColumnName("IT_bill");

                entity.Property(e => e.PoorFund).HasColumnName("Poor_fund");

                entity.Property(e => e.SchoolDev).HasColumnName("School_dev");

                entity.Property(e => e.SchoolMaintenance).HasColumnName("School_maintenance");

                entity.Property(e => e.ScienceFairCost).HasColumnName("Science_fair_cost");

                entity.Property(e => e.ServicingCharge).HasColumnName("Servicing_charge");

                entity.Property(e => e.StudyTourCost).HasColumnName("Study_tour_cost");

                entity.Property(e => e.WaterBillAmount).HasColumnName("Water_bill_amount");

                entity.Property(e => e.WaterBillMonth)
                    .HasColumnName("Water_bill_month")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pretest>(entity =>
            {
                entity.HasKey(e => e.PretesetId);

                entity.ToTable("pretest");

                entity.Property(e => e.PretesetId).HasColumnName("preteset_id");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Obj).HasColumnName("obj");

                entity.Property(e => e.Practical).HasColumnName("practical");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Sub).HasColumnName("sub");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Pretest)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pretest_exam_info");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Pretest)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pretest_student_info");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Pretest)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pretest_subject_info");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Pretest)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pretest_teacher_info");
            });

            modelBuilder.Entity<SectionInfo>(entity =>
            {
                entity.HasKey(e => e.SectionId);

                entity.ToTable("section_info");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasColumnName("section_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SectionInfo)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_section_info_class_info");
            });

            modelBuilder.Entity<ShiftInfo>(entity =>
            {
                entity.HasKey(e => e.ShiftId);

                entity.ToTable("shift_info");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasColumnName("shift_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StaffInfo>(entity =>
            {
                entity.HasKey(e => e.SsId);

                entity.ToTable("Staff_Info");

                entity.Property(e => e.SsId)
                    .HasColumnName("SS_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StaffId).HasColumnName("Staff_id");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasColumnName("Staff_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.WorkingSector)
                    .IsRequired()
                    .HasColumnName("Working_Sector")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Ss)
                    .WithOne(p => p.StaffInfo)
                    .HasForeignKey<StaffInfo>(d => d.SsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Info_Staff_salary");
            });

            modelBuilder.Entity<StaffSalary>(entity =>
            {
                entity.HasKey(e => e.SsId);

                entity.ToTable("Staff_salary");

                entity.Property(e => e.SsId).HasColumnName("SS_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.MonthName)
                    .IsRequired()
                    .HasColumnName("Month_name")
                    .HasMaxLength(50);

                entity.Property(e => e.StaffId).HasColumnName("Staff_id");
            });

            modelBuilder.Entity<StudentInfo>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("student_info");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasColumnName("student_name")
                    .HasMaxLength(50);

                entity.Property(e => e.StudentRoll).HasColumnName("student_roll");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentInfo)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_info_class_info");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentInfo)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_info_group_info");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.StudentInfo)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_info_section_info");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.StudentInfo)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_info_shift_info");
            });

            modelBuilder.Entity<StudentPayment>(entity =>
            {
                entity.HasKey(e => e.SpId);

                entity.ToTable("Student_payment");

                entity.Property(e => e.SpId).HasColumnName("SP_id");

                entity.Property(e => e.AdmissionFee).HasColumnName("Admission_fee");

                entity.Property(e => e.AdmitCardFee).HasColumnName("Admit_card_fee");

                entity.Property(e => e.BuildingDevFee).HasColumnName("Building_dev_fee");

                entity.Property(e => e.CareFee).HasColumnName("Care_fee");

                entity.Property(e => e.CautionMoney).HasColumnName("Caution_money");

                entity.Property(e => e.CertificateFee).HasColumnName("Certificate_fee");

                entity.Property(e => e.ComputerFee).HasColumnName("Computer_fee");

                entity.Property(e => e.Ct1Fee).HasColumnName("CT_1_fee");

                entity.Property(e => e.Ct2Fee).HasColumnName("CT_2_fee");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DevlopmentFee).HasColumnName("Devlopment_fee");

                entity.Property(e => e.FinalYearlyFee).HasColumnName("Final_yearly_fee");

                entity.Property(e => e.FormFee).HasColumnName("Form_fee");

                entity.Property(e => e.FormFillUpEFf).HasColumnName("Form_fill_up_eFF");

                entity.Property(e => e.FormFillUpHsc).HasColumnName("Form_fill_up_HSC");

                entity.Property(e => e.FormFillUpJsc).HasColumnName("Form_fill_up_JSC");

                entity.Property(e => e.FormFillUpSsc).HasColumnName("Form_fill_up_SSC");

                entity.Property(e => e.HalfYearlyFee).HasColumnName("Half_yearly_fee");

                entity.Property(e => e.IdCardFee).HasColumnName("ID_card_fee");

                entity.Property(e => e.ItFee).HasColumnName("IT_fee");

                entity.Property(e => e.LabFee).HasColumnName("Lab_fee");

                entity.Property(e => e.LibraryFee).HasColumnName("Library_fee");

                entity.Property(e => e.MonthFeeAmount).HasColumnName("Month_fee_amount");

                entity.Property(e => e.OtherFeeAmount).HasColumnName("Other_fee_amount");

                entity.Property(e => e.OtherFeeName)
                    .HasColumnName("Other_fee_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ReAdmissionFee).HasColumnName("Re_admission_fee");

                entity.Property(e => e.RegistrationFee).HasColumnName("Registration_fee");

                entity.Property(e => e.ReportCardFee).HasColumnName("Report_card_fee");

                entity.Property(e => e.ScienceDevelopmentFee).HasColumnName("Science_development_fee");

                entity.Property(e => e.SeasonCharge).HasColumnName("Season_Charge");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.TcCharge).HasColumnName("TC_charge");

                entity.Property(e => e.TestimonialFee).HasColumnName("Testimonial_fee");

                entity.Property(e => e.WaterElectricityFee).HasColumnName("Water_electricity_fee");

                entity.Property(e => e.WhichMonthFee)
                    .HasColumnName("Which_month_fee")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPayment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_payment_student_info");
            });

            modelBuilder.Entity<SubjectInfo>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("subject_info");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("subject_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SubjectInfo)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subject_info_class_info");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SubjectInfo)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subject_info_group_info");
            });

            modelBuilder.Entity<TeacherInfo>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.ToTable("teacher_info");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.Cell).HasColumnName("cell");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasColumnName("teacher_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherInfo)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_teacher_info_subject_info");
            });

            modelBuilder.Entity<TeacherSalary>(entity =>
            {
                entity.HasKey(e => e.TsId);

                entity.ToTable("Teacher_salary");

                entity.Property(e => e.TsId).HasColumnName("TS_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.MonthName)
                    .IsRequired()
                    .HasColumnName("Month_name")
                    .HasMaxLength(50);

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherSalary)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_salary_teacher_info1");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.TestId).HasColumnName("test_id");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Obj).HasColumnName("obj");

                entity.Property(e => e.Practical).HasColumnName("practical");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Sub).HasColumnName("sub");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_exam_info");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_student_info");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_subject_info");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_test_teacher_info");
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConfirmPassword).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Role).HasMaxLength(50);
            });
        }
    }
}
