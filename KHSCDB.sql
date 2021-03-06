USE [KHSCDB]
GO
/****** Object:  Schema [edu]    Script Date: 8/7/2019 7:40:45 AM ******/
CREATE SCHEMA [edu]
GO
/****** Object:  Table [dbo].[AdmissionForm]    Script Date: 8/7/2019 7:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdmissionForm](
	[AF_id] [int] IDENTITY(1,1) NOT NULL,
	[AdmitCardNo] [int] NOT NULL,
	[AdmissionDate] [date] NOT NULL,
	[CollegeRoll] [int] NOT NULL,
	[Section] [nvarchar](50) NOT NULL,
	[ElectiveSubject1] [nvarchar](50) NOT NULL,
	[ElectiveSubject2] [nvarchar](50) NOT NULL,
	[ElectiveSubject3] [nvarchar](50) NOT NULL,
	[FourthSubject] [nvarchar](50) NOT NULL,
	[NameOftheStudent] [nvarchar](50) NOT NULL,
	[DateOfBirth] [nvarchar](50) NOT NULL,
	[Religion] [nvarchar](50) NOT NULL,
	[Nationality] [nvarchar](50) NOT NULL,
	[Height] [nvarchar](50) NOT NULL,
	[Weight] [nvarchar](50) NOT NULL,
	[BloodGroup] [nvarchar](50) NOT NULL,
	[FathersName] [nvarchar](50) NOT NULL,
	[FathersEducationalQualification] [nvarchar](50) NOT NULL,
	[FathersOccupation] [nvarchar](50) NOT NULL,
	[FathersMobileNo] [nvarchar](50) NOT NULL,
	[Father_NID] [int] NOT NULL,
	[MothersName] [nvarchar](50) NOT NULL,
	[MothersEducationalQualification] [nvarchar](50) NOT NULL,
	[MothersOccupation] [nvarchar](50) NOT NULL,
	[MothersMobileNo] [nvarchar](50) NOT NULL,
	[Mother_NID] [int] NOT NULL,
	[PresentAddress] [nvarchar](50) NOT NULL,
	[PermanentAddress] [nvarchar](50) NOT NULL,
	[NameOfGuardian] [nvarchar](50) NOT NULL,
	[GuardianAddress] [nvarchar](50) NOT NULL,
	[GuardianMobileNo] [nvarchar](50) NOT NULL,
	[FathersTotalAnnualincome] [nvarchar](50) NOT NULL,
	[JSCYearOfTheExam] [nvarchar](50) NOT NULL,
	[JSCNameOfTheBoard] [nvarchar](50) NOT NULL,
	[JSCRoolNo] [nvarchar](50) NOT NULL,
	[JSCRegistrationNo] [nvarchar](50) NOT NULL,
	[JSCSession] [nvarchar](50) NOT NULL,
	[JSC_GPA] [nvarchar](50) NOT NULL,
	[JSCNameOfInstitution] [nvarchar](50) NOT NULL,
	[SSCYearOfTheExam] [nvarchar](50) NOT NULL,
	[SSCNameOfTheBoard] [nvarchar](50) NOT NULL,
	[SSCRoolNo] [nvarchar](50) NOT NULL,
	[SSCRegistrationNo] [nvarchar](50) NOT NULL,
	[SSCSession] [nvarchar](50) NOT NULL,
	[SSC_GPA] [nvarchar](50) NOT NULL,
	[SSCNameOfInstitution] [nvarchar](50) NOT NULL,
	[NameOfTheLastSchoolorCollegeAttended] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AdmissionForm_1] PRIMARY KEY CLUSTERED 
(
	[AF_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[class_info]    Script Date: 8/7/2019 7:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[class_info](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[class_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_class_info] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[enrollment]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enrollment](
	[et_id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[section_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[year] [int] NOT NULL,
 CONSTRAINT [PK_enrollment] PRIMARY KEY CLUSTERED 
(
	[et_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[exam_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exam_info](
	[exam_id] [int] IDENTITY(1,1) NOT NULL,
	[exam_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_exam_info] PRIMARY KEY CLUSTERED 
(
	[exam_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[final_year_result]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[final_year_result](
	[fy] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[ct_2] [int] NOT NULL,
	[sub] [int] NOT NULL,
	[obj] [int] NOT NULL,
	[practical] [int] NOT NULL,
	[attendance] [int] NOT NULL,
 CONSTRAINT [PK_final_year_result] PRIMARY KEY CLUSTERED 
(
	[fy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Government_payment]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Government_payment](
	[GP_id] [int] IDENTITY(1,1) NOT NULL,
	[Month_name] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Government_payment] PRIMARY KEY CLUSTERED 
(
	[GP_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grade_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grade_info](
	[grade_id] [int] IDENTITY(1,1) NOT NULL,
	[grade] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_grade_info] PRIMARY KEY CLUSTERED 
(
	[grade_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[group_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[group_info](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[group_name] [nvarchar](50) NOT NULL,
	[section_id] [int] NOT NULL,
 CONSTRAINT [PK_group_info] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[half_year_result]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[half_year_result](
	[hy] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[ct_1] [int] NOT NULL,
	[sub] [int] NOT NULL,
	[obj] [int] NOT NULL,
	[practical] [int] NOT NULL,
	[attendence] [int] NOT NULL,
 CONSTRAINT [PK_half_year_result] PRIMARY KEY CLUSTERED 
(
	[hy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Other_Cost_Info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Other_Cost_Info](
	[OC_id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[electricity_bill_month_name] [nvarchar](50) NULL,
	[Electricity_bill_amount] [int] NULL,
	[Water_bill_month] [nvarchar](50) NULL,
	[Water_bill_amount] [int] NULL,
	[IT_bill] [int] NULL,
	[Function_cost] [int] NULL,
	[Science_fair_cost] [int] NULL,
	[Study_tour_cost] [int] NULL,
	[Poor_fund] [int] NULL,
	[School_dev] [int] NULL,
	[School_maintenance] [int] NULL,
	[Servicing_charge] [int] NULL,
	[Any cost_name] [int] NULL,
	[Any_cost_fee] [int] NULL,
 CONSTRAINT [PK_Other_Cost_Info] PRIMARY KEY CLUSTERED 
(
	[OC_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pretest]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pretest](
	[preteset_id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[sub] [int] NOT NULL,
	[obj] [int] NOT NULL,
	[attendance] [int] NOT NULL,
	[practical] [int] NOT NULL,
 CONSTRAINT [PK_pretest] PRIMARY KEY CLUSTERED 
(
	[preteset_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[section_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[section_info](
	[section_id] [int] IDENTITY(1,1) NOT NULL,
	[section_name] [nvarchar](50) NOT NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_section_info] PRIMARY KEY CLUSTERED 
(
	[section_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shift_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shift_info](
	[shift_id] [int] IDENTITY(1,1) NOT NULL,
	[shift_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_shift_info] PRIMARY KEY CLUSTERED 
(
	[shift_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff_Info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff_Info](
	[SS_id] [int] IDENTITY(1,1) NOT NULL,
	[Staff_id] [int] NOT NULL,
	[Staff_Name] [nvarchar](50) NOT NULL,
	[Working_Sector] [nvarchar](50) NOT NULL,
	[Cell] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Staff_Info_1] PRIMARY KEY CLUSTERED 
(
	[SS_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff_salary]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff_salary](
	[SS_id] [int] IDENTITY(1,1) NOT NULL,
	[Staff_id] [int] NOT NULL,
	[Month_name] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Staff_salary] PRIMARY KEY CLUSTERED 
(
	[SS_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student_info](
	[student_id] [int] IDENTITY(1,1) NOT NULL,
	[student_name] [nvarchar](50) NOT NULL,
	[student_roll] [int] NOT NULL,
	[section_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[shift_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[year] [int] NOT NULL,
 CONSTRAINT [PK_student_info] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_payment]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_payment](
	[SP_id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Form_fee] [int] NULL,
	[Admission_fee] [int] NULL,
	[Re_admission_fee] [int] NULL,
	[TC_charge] [int] NULL,
	[Season_Charge] [int] NULL,
	[Certificate_fee] [int] NULL,
	[Testimonial_fee] [int] NULL,
	[Which_month_fee] [nvarchar](50) NULL,
	[Month_fee_amount] [int] NULL,
	[CT_1_fee] [int] NULL,
	[CT_2_fee] [int] NULL,
	[Half_yearly_fee] [int] NULL,
	[Final_yearly_fee] [int] NULL,
	[Water_electricity_fee] [int] NULL,
	[Tex] [int] NULL,
	[Devlopment_fee] [int] NULL,
	[Building_dev_fee] [int] NULL,
	[Lab_fee] [int] NULL,
	[Library_fee] [int] NULL,
	[Computer_fee] [int] NULL,
	[Registration_fee] [int] NULL,
	[Caution_money] [int] NULL,
	[Fine] [int] NULL,
	[Report_card_fee] [int] NULL,
	[Admit_card_fee] [int] NULL,
	[ID_card_fee] [int] NULL,
	[Form_fill_up_eFF] [int] NULL,
	[Form_fill_up_JSC] [int] NULL,
	[Form_fill_up_SSC] [int] NULL,
	[Form_fill_up_HSC] [int] NULL,
	[IT_fee] [int] NULL,
	[Science_development_fee] [int] NULL,
	[Care_fee] [int] NULL,
	[Other_fee_name] [nvarchar](50) NULL,
	[Other_fee_amount] [int] NULL,
 CONSTRAINT [PK_Student_payment] PRIMARY KEY CLUSTERED 
(
	[SP_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subject_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subject_info](
	[subject_id] [int] NOT NULL,
	[subject_name] [nvarchar](50) NOT NULL,
	[group_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_subject_info] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teacher_info]    Script Date: 8/7/2019 7:40:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher_info](
	[teacher_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_name] [nvarchar](50) NOT NULL,
	[subject_id] [int] NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[cell] [int] NOT NULL,
	[position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_teache_info] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher_salary]    Script Date: 8/7/2019 7:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher_salary](
	[TS_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_id] [int] NOT NULL,
	[Month_name] [nvarchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Teacher_salary] PRIMARY KEY CLUSTERED 
(
	[TS_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test]    Script Date: 8/7/2019 7:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test](
	[test_id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[sub] [int] NOT NULL,
	[obj] [int] NOT NULL,
	[practical] [int] NOT NULL,
	[attendance] [int] NOT NULL,
 CONSTRAINT [PK_test] PRIMARY KEY CLUSTERED 
(
	[test_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccounts]    Script Date: 8/7/2019 7:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ConfirmPassword] [nvarchar](50) NULL,
	[UserRole] [int] NOT NULL,
 CONSTRAINT [PK_UserAccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 8/7/2019 7:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[class_info] ON 

INSERT [dbo].[class_info] ([class_id], [class_name]) VALUES (1, N'Class 8')
INSERT [dbo].[class_info] ([class_id], [class_name]) VALUES (2, N'Class 10')
INSERT [dbo].[class_info] ([class_id], [class_name]) VALUES (3, N'Class 11')
SET IDENTITY_INSERT [dbo].[class_info] OFF
SET IDENTITY_INSERT [dbo].[enrollment] ON 

INSERT [dbo].[enrollment] ([et_id], [student_id], [teacher_id], [class_id], [section_id], [subject_id], [year]) VALUES (1, 1, 1, 1, 1, 1, 2019)
SET IDENTITY_INSERT [dbo].[enrollment] OFF
SET IDENTITY_INSERT [dbo].[exam_info] ON 

INSERT [dbo].[exam_info] ([exam_id], [exam_name]) VALUES (1, N'First Term')
INSERT [dbo].[exam_info] ([exam_id], [exam_name]) VALUES (2, N'Mid Term')
SET IDENTITY_INSERT [dbo].[exam_info] OFF
SET IDENTITY_INSERT [dbo].[grade_info] ON 

INSERT [dbo].[grade_info] ([grade_id], [grade]) VALUES (1, N'A')
INSERT [dbo].[grade_info] ([grade_id], [grade]) VALUES (2, N'A+')
INSERT [dbo].[grade_info] ([grade_id], [grade]) VALUES (3, N'A-')
INSERT [dbo].[grade_info] ([grade_id], [grade]) VALUES (4, N'B+')
SET IDENTITY_INSERT [dbo].[grade_info] OFF
SET IDENTITY_INSERT [dbo].[group_info] ON 

INSERT [dbo].[group_info] ([group_id], [group_name], [section_id]) VALUES (1, N'Science', 1)
INSERT [dbo].[group_info] ([group_id], [group_name], [section_id]) VALUES (2, N'Arts', 1)
SET IDENTITY_INSERT [dbo].[group_info] OFF
SET IDENTITY_INSERT [dbo].[half_year_result] ON 

INSERT [dbo].[half_year_result] ([hy], [student_id], [teacher_id], [subject_id], [exam_id], [ct_1], [sub], [obj], [practical], [attendence]) VALUES (1, 1, 1, 1, 1, 20, 40, 20, 20, 80)
SET IDENTITY_INSERT [dbo].[half_year_result] OFF
SET IDENTITY_INSERT [dbo].[section_info] ON 

INSERT [dbo].[section_info] ([section_id], [section_name], [class_id]) VALUES (1, N'A', 1)
INSERT [dbo].[section_info] ([section_id], [section_name], [class_id]) VALUES (2, N'B', 1)
INSERT [dbo].[section_info] ([section_id], [section_name], [class_id]) VALUES (3, N'A', 2)
INSERT [dbo].[section_info] ([section_id], [section_name], [class_id]) VALUES (4, N'A', 3)
SET IDENTITY_INSERT [dbo].[section_info] OFF
SET IDENTITY_INSERT [dbo].[shift_info] ON 

INSERT [dbo].[shift_info] ([shift_id], [shift_name]) VALUES (1, N'Morning')
SET IDENTITY_INSERT [dbo].[shift_info] OFF
SET IDENTITY_INSERT [dbo].[student_info] ON 

INSERT [dbo].[student_info] ([student_id], [student_name], [student_roll], [section_id], [class_id], [shift_id], [group_id], [year]) VALUES (1, N'Rafi Islam', 1, 2, 2, 1, 1, 2019)
INSERT [dbo].[student_info] ([student_id], [student_name], [student_roll], [section_id], [class_id], [shift_id], [group_id], [year]) VALUES (2, N'Rafsan Alam', 2, 1, 1, 1, 1, 2019)
SET IDENTITY_INSERT [dbo].[student_info] OFF
INSERT [dbo].[subject_info] ([subject_id], [subject_name], [group_id], [class_id]) VALUES (1, N'Bangla', 1, 1)
INSERT [dbo].[subject_info] ([subject_id], [subject_name], [group_id], [class_id]) VALUES (2, N'Math', 1, 1)
SET IDENTITY_INSERT [dbo].[teacher_info] ON 

INSERT [dbo].[teacher_info] ([teacher_id], [teacher_name], [subject_id], [email], [cell], [position]) VALUES (1, N'Nazrul Islam', 2, N'nazrul@gmail.com', 1684360776, N'Junior Teacher')
SET IDENTITY_INSERT [dbo].[teacher_info] OFF
SET IDENTITY_INSERT [dbo].[UserAccounts] ON 

INSERT [dbo].[UserAccounts] ([id], [Username], [Password], [ConfirmPassword], [UserRole]) VALUES (1, N'jasper', N'2', N'2', 1)
INSERT [dbo].[UserAccounts] ([id], [Username], [Password], [ConfirmPassword], [UserRole]) VALUES (2, N'r', N'1', N'1', 1)
INSERT [dbo].[UserAccounts] ([id], [Username], [Password], [ConfirmPassword], [UserRole]) VALUES (3, N's', N'1', N'1', 2)
INSERT [dbo].[UserAccounts] ([id], [Username], [Password], [ConfirmPassword], [UserRole]) VALUES (4, N't', N'1', N'1', 3)
SET IDENTITY_INSERT [dbo].[UserAccounts] OFF
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([id], [Role]) VALUES (2, N'Registry')
INSERT [dbo].[UserRoles] ([id], [Role]) VALUES (3, N'Teacher')
INSERT [dbo].[UserRoles] ([id], [Role]) VALUES (4, N'Student')
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
ALTER TABLE [dbo].[enrollment]  WITH CHECK ADD  CONSTRAINT [FK_enrollment_class_info] FOREIGN KEY([class_id])
REFERENCES [dbo].[class_info] ([class_id])
GO
ALTER TABLE [dbo].[enrollment] CHECK CONSTRAINT [FK_enrollment_class_info]
GO
ALTER TABLE [dbo].[enrollment]  WITH CHECK ADD  CONSTRAINT [FK_enrollment_section_info] FOREIGN KEY([section_id])
REFERENCES [dbo].[section_info] ([section_id])
GO
ALTER TABLE [dbo].[enrollment] CHECK CONSTRAINT [FK_enrollment_section_info]
GO
ALTER TABLE [dbo].[enrollment]  WITH CHECK ADD  CONSTRAINT [FK_enrollment_student_info] FOREIGN KEY([student_id])
REFERENCES [dbo].[student_info] ([student_id])
GO
ALTER TABLE [dbo].[enrollment] CHECK CONSTRAINT [FK_enrollment_student_info]
GO
ALTER TABLE [dbo].[enrollment]  WITH CHECK ADD  CONSTRAINT [FK_enrollment_subject_info] FOREIGN KEY([subject_id])
REFERENCES [dbo].[subject_info] ([subject_id])
GO
ALTER TABLE [dbo].[enrollment] CHECK CONSTRAINT [FK_enrollment_subject_info]
GO
ALTER TABLE [dbo].[enrollment]  WITH CHECK ADD  CONSTRAINT [FK_enrollment_teacher_info] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teacher_info] ([teacher_id])
GO
ALTER TABLE [dbo].[enrollment] CHECK CONSTRAINT [FK_enrollment_teacher_info]
GO
ALTER TABLE [dbo].[final_year_result]  WITH CHECK ADD  CONSTRAINT [FK_final_year_result_exam_info] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam_info] ([exam_id])
GO
ALTER TABLE [dbo].[final_year_result] CHECK CONSTRAINT [FK_final_year_result_exam_info]
GO
ALTER TABLE [dbo].[final_year_result]  WITH CHECK ADD  CONSTRAINT [FK_final_year_result_student_info] FOREIGN KEY([student_id])
REFERENCES [dbo].[student_info] ([student_id])
GO
ALTER TABLE [dbo].[final_year_result] CHECK CONSTRAINT [FK_final_year_result_student_info]
GO
ALTER TABLE [dbo].[final_year_result]  WITH CHECK ADD  CONSTRAINT [FK_final_year_result_subject_info] FOREIGN KEY([subject_id])
REFERENCES [dbo].[subject_info] ([subject_id])
GO
ALTER TABLE [dbo].[final_year_result] CHECK CONSTRAINT [FK_final_year_result_subject_info]
GO
ALTER TABLE [dbo].[final_year_result]  WITH CHECK ADD  CONSTRAINT [FK_final_year_result_teacher_info] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teacher_info] ([teacher_id])
GO
ALTER TABLE [dbo].[final_year_result] CHECK CONSTRAINT [FK_final_year_result_teacher_info]
GO
ALTER TABLE [dbo].[group_info]  WITH CHECK ADD  CONSTRAINT [FK_group_info_section_info] FOREIGN KEY([section_id])
REFERENCES [dbo].[section_info] ([section_id])
GO
ALTER TABLE [dbo].[group_info] CHECK CONSTRAINT [FK_group_info_section_info]
GO
ALTER TABLE [dbo].[half_year_result]  WITH CHECK ADD  CONSTRAINT [FK_half_year_result_exam_info] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam_info] ([exam_id])
GO
ALTER TABLE [dbo].[half_year_result] CHECK CONSTRAINT [FK_half_year_result_exam_info]
GO
ALTER TABLE [dbo].[half_year_result]  WITH CHECK ADD  CONSTRAINT [FK_half_year_result_student_info] FOREIGN KEY([student_id])
REFERENCES [dbo].[student_info] ([student_id])
GO
ALTER TABLE [dbo].[half_year_result] CHECK CONSTRAINT [FK_half_year_result_student_info]
GO
ALTER TABLE [dbo].[half_year_result]  WITH CHECK ADD  CONSTRAINT [FK_half_year_result_subject_info] FOREIGN KEY([subject_id])
REFERENCES [dbo].[subject_info] ([subject_id])
GO
ALTER TABLE [dbo].[half_year_result] CHECK CONSTRAINT [FK_half_year_result_subject_info]
GO
ALTER TABLE [dbo].[half_year_result]  WITH CHECK ADD  CONSTRAINT [FK_half_year_result_teacher_info] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teacher_info] ([teacher_id])
GO
ALTER TABLE [dbo].[half_year_result] CHECK CONSTRAINT [FK_half_year_result_teacher_info]
GO
ALTER TABLE [dbo].[pretest]  WITH CHECK ADD  CONSTRAINT [FK_pretest_exam_info] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam_info] ([exam_id])
GO
ALTER TABLE [dbo].[pretest] CHECK CONSTRAINT [FK_pretest_exam_info]
GO
ALTER TABLE [dbo].[pretest]  WITH CHECK ADD  CONSTRAINT [FK_pretest_student_info] FOREIGN KEY([student_id])
REFERENCES [dbo].[student_info] ([student_id])
GO
ALTER TABLE [dbo].[pretest] CHECK CONSTRAINT [FK_pretest_student_info]
GO
ALTER TABLE [dbo].[pretest]  WITH CHECK ADD  CONSTRAINT [FK_pretest_subject_info] FOREIGN KEY([subject_id])
REFERENCES [dbo].[subject_info] ([subject_id])
GO
ALTER TABLE [dbo].[pretest] CHECK CONSTRAINT [FK_pretest_subject_info]
GO
ALTER TABLE [dbo].[pretest]  WITH CHECK ADD  CONSTRAINT [FK_pretest_teacher_info] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teacher_info] ([teacher_id])
GO
ALTER TABLE [dbo].[pretest] CHECK CONSTRAINT [FK_pretest_teacher_info]
GO
ALTER TABLE [dbo].[section_info]  WITH CHECK ADD  CONSTRAINT [FK_section_info_class_info] FOREIGN KEY([class_id])
REFERENCES [dbo].[class_info] ([class_id])
GO
ALTER TABLE [dbo].[section_info] CHECK CONSTRAINT [FK_section_info_class_info]
GO
ALTER TABLE [dbo].[Staff_Info]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Info_Staff_salary] FOREIGN KEY([SS_id])
REFERENCES [dbo].[Staff_salary] ([SS_id])
GO
ALTER TABLE [dbo].[Staff_Info] CHECK CONSTRAINT [FK_Staff_Info_Staff_salary]
GO
ALTER TABLE [dbo].[student_info]  WITH CHECK ADD  CONSTRAINT [FK_student_info_class_info] FOREIGN KEY([class_id])
REFERENCES [dbo].[class_info] ([class_id])
GO
ALTER TABLE [dbo].[student_info] CHECK CONSTRAINT [FK_student_info_class_info]
GO
ALTER TABLE [dbo].[student_info]  WITH CHECK ADD  CONSTRAINT [FK_student_info_group_info] FOREIGN KEY([group_id])
REFERENCES [dbo].[group_info] ([group_id])
GO
ALTER TABLE [dbo].[student_info] CHECK CONSTRAINT [FK_student_info_group_info]
GO
ALTER TABLE [dbo].[student_info]  WITH CHECK ADD  CONSTRAINT [FK_student_info_section_info] FOREIGN KEY([section_id])
REFERENCES [dbo].[section_info] ([section_id])
GO
ALTER TABLE [dbo].[student_info] CHECK CONSTRAINT [FK_student_info_section_info]
GO
ALTER TABLE [dbo].[student_info]  WITH CHECK ADD  CONSTRAINT [FK_student_info_shift_info] FOREIGN KEY([shift_id])
REFERENCES [dbo].[shift_info] ([shift_id])
GO
ALTER TABLE [dbo].[student_info] CHECK CONSTRAINT [FK_student_info_shift_info]
GO
ALTER TABLE [dbo].[Student_payment]  WITH CHECK ADD  CONSTRAINT [FK_Student_payment_student_info] FOREIGN KEY([student_id])
REFERENCES [dbo].[student_info] ([student_id])
GO
ALTER TABLE [dbo].[Student_payment] CHECK CONSTRAINT [FK_Student_payment_student_info]
GO
ALTER TABLE [dbo].[subject_info]  WITH CHECK ADD  CONSTRAINT [FK_subject_info_class_info] FOREIGN KEY([class_id])
REFERENCES [dbo].[class_info] ([class_id])
GO
ALTER TABLE [dbo].[subject_info] CHECK CONSTRAINT [FK_subject_info_class_info]
GO
ALTER TABLE [dbo].[subject_info]  WITH CHECK ADD  CONSTRAINT [FK_subject_info_group_info] FOREIGN KEY([group_id])
REFERENCES [dbo].[group_info] ([group_id])
GO
ALTER TABLE [dbo].[subject_info] CHECK CONSTRAINT [FK_subject_info_group_info]
GO
ALTER TABLE [dbo].[teacher_info]  WITH CHECK ADD  CONSTRAINT [FK_teacher_info_subject_info] FOREIGN KEY([subject_id])
REFERENCES [dbo].[subject_info] ([subject_id])
GO
ALTER TABLE [dbo].[teacher_info] CHECK CONSTRAINT [FK_teacher_info_subject_info]
GO
ALTER TABLE [dbo].[Teacher_salary]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_salary_teacher_info] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teacher_info] ([teacher_id])
GO
ALTER TABLE [dbo].[Teacher_salary] CHECK CONSTRAINT [FK_Teacher_salary_teacher_info]
GO
ALTER TABLE [dbo].[Teacher_salary]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_salary_teacher_info1] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teacher_info] ([teacher_id])
GO
ALTER TABLE [dbo].[Teacher_salary] CHECK CONSTRAINT [FK_Teacher_salary_teacher_info1]
GO
ALTER TABLE [dbo].[test]  WITH CHECK ADD  CONSTRAINT [FK_test_exam_info] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam_info] ([exam_id])
GO
ALTER TABLE [dbo].[test] CHECK CONSTRAINT [FK_test_exam_info]
GO
ALTER TABLE [dbo].[test]  WITH CHECK ADD  CONSTRAINT [FK_test_student_info] FOREIGN KEY([student_id])
REFERENCES [dbo].[student_info] ([student_id])
GO
ALTER TABLE [dbo].[test] CHECK CONSTRAINT [FK_test_student_info]
GO
ALTER TABLE [dbo].[test]  WITH CHECK ADD  CONSTRAINT [FK_test_subject_info] FOREIGN KEY([subject_id])
REFERENCES [dbo].[subject_info] ([subject_id])
GO
ALTER TABLE [dbo].[test] CHECK CONSTRAINT [FK_test_subject_info]
GO
ALTER TABLE [dbo].[test]  WITH CHECK ADD  CONSTRAINT [FK_test_teacher_info] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[teacher_info] ([teacher_id])
GO
ALTER TABLE [dbo].[test] CHECK CONSTRAINT [FK_test_teacher_info]
GO
