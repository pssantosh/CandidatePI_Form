
IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[Candidate]') AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[CandidateAdmin](
	[CandidateAdminId] [int] IDENTITY(1,1) NOT NULL,
	[CandidateEmail] [nvarchar](50) NOT NULL,
	[UniqueKey] [uniqueidentifier] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[IsFinalized] [bit] NOT NULL,
 CONSTRAINT [PK_CandidateAdmin] PRIMARY KEY CLUSTERED 
(
	[CandidateAdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO



IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[Candidate]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[Candidate](
	[CandidateId] [int] IDENTITY(1,1) NOT NULL,
	[Prefix] [nvarchar](5) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[MaritalStatus] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Anniversary] [datetime] NULL,
	[Qualification] [nvarchar](50) NOT NULL,
	[WorkExperience] [nvarchar](50) NOT NULL,
	[PanCardNumber] [nvarchar](50) NULL,
	[AadharCardNumber] [nvarchar](50) NULL,
	[UanNumber] [nvarchar](50) NULL,
	[PassportNumber] [nvarchar](50) NULL,
	[PassportExpiry] [DateTime] NULL,
	[PassportIssuePlace] [nvarchar](50) NULL,
	[Visa] [nvarchar](50) NULL,
	[VisaExpiry] [DateTime] NULL,
	[CandidateAdminId] [int] NOT NULL,
	 CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED 
	(
		[CandidateId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]



	ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD  CONSTRAINT [FK_Candidate_CandidateAdminId] FOREIGN KEY([CandidateAdminId])
	REFERENCES [dbo].[CandidateAdmin] ([CandidateAdminId])


	ALTER TABLE [dbo].[Candidate] CHECK CONSTRAINT [FK_Candidate_CandidateAdminId]

END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateAddress]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[CandidateAddress](
	[CandidateAddressId] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [int] NOT NULL,
	[AddressType] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[PinCode] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[LandMark] [nvarchar](50) NULL,
	 CONSTRAINT [PK_CandidateAddress] PRIMARY KEY CLUSTERED 
	(
		[CandidateAddressId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[CandidateAddress]  WITH CHECK ADD  CONSTRAINT [FK_CandidateAddress_CandidateID] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])

	ALTER TABLE [dbo].[CandidateAddress] CHECK CONSTRAINT [FK_CandidateAddress_CandidateID]

END

GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateContact]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[CandidateContact](
	[CandidateContactId] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [int] NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[MobileNumber] [nvarchar](50) NOT NULL,
	[LandlineContactNumber] [nvarchar](50) NULL,
	[EmergencyContactNumber] [nvarchar](50) NULL,
	 CONSTRAINT [PK_CandidateContact] PRIMARY KEY CLUSTERED 
	(
		[CandidateContactId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[CandidateContact]  WITH CHECK ADD  CONSTRAINT [FK_CandidateContact_CandidateID] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])

	ALTER TABLE [dbo].[CandidateContact] CHECK CONSTRAINT [FK_CandidateContact_CandidateID]

END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateDependents]') AND type in (N'U'))
BEGIN


	CREATE TABLE [dbo].[CandidateDependents](
		[CandidateDependentId] [int] IDENTITY(1,1) NOT NULL,
		[CandidateId] [int] NOT NULL,
		[FatherName] [nvarchar](50) NOT NULL,
		[FatherBirthDate] [datetime] NULL,
		[MotherName] [nvarchar](50) NOT NULL,
		[MotherBirthDate] [datetime] NULL,
		[SpouseName] [nvarchar](50) NULL,
		[SpouseBirthDate] [datetime] NULL,
		[FirstChildName] [nvarchar](50) NULL,
		[FirstChildBirthDate] [datetime] NULL,
		[SecondChildName] [nvarchar](50) NULL,
		[SecondChildBirthDate] [datetime] NULL,
	 CONSTRAINT [PK_CandidateDependents] PRIMARY KEY CLUSTERED 
	(
		[CandidateDependentId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[CandidateDependents]  WITH CHECK ADD  CONSTRAINT [FK_CandidateDependents_Candidate] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])
	
	ALTER TABLE [dbo].[CandidateDependents] CHECK CONSTRAINT [FK_CandidateDependents_Candidate]
	
END
GO



IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateEducationDetails]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[CandidateEducationDetails](
	[CandidateEducationDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [int] NOT NULL,
	[UniversityName] [nvarchar](50) NOT NULL,
	[UniversityAddress] [nvarchar](100) NULL,
	[UniversityContactNumber] [nvarchar](50) NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[Course] [nvarchar](50) NOT NULL,
	[Specialization] [nvarchar](50) NULL,
	[CollegeName] [nvarchar](50) NULL,
	[CollegeAddress] [nvarchar](100) NULL,
	[CollegeContact] [nvarchar](50) NULL,
	[CourseStartDate] [nvarchar](50) NULL,
	[CourseEndDate] [nvarchar](50) NULL,
	[FileNamePath] [nvarchar](50)  NULL,
	 CONSTRAINT [PK_CandidateEducationDetails] PRIMARY KEY CLUSTERED 
	(
		[CandidateEducationDetailsId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[CandidateEducationDetails]  WITH CHECK ADD  CONSTRAINT [FK_CandidateEducationDetails_CandidateId] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])


	ALTER TABLE [dbo].[CandidateEducationDetails] CHECK CONSTRAINT [FK_CandidateEducationDetails_CandidateId]

END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateTrainings]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[CandidateTrainings](
		[CandidateTrainingsId] [int] IDENTITY(1,1) NOT NULL,
		[CandidateId] [int] NOT NULL,
		[Trainings] [nvarchar](50) NOT NULL,
		[Institute] [nvarchar](50) NOT NULL,
		[TrainingStartDate] [nvarchar](50)NULL,
		[TrainingEndDate] [nvarchar](50) NULL,
		[Certifications] [nvarchar](50) NULL,
	 CONSTRAINT [PK_CandidateTrainings] PRIMARY KEY CLUSTERED 
	(
		[CandidateTrainingsId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[CandidateTrainings]  WITH CHECK ADD  CONSTRAINT [FK_CandidateTrainings_CandidateId] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])

	ALTER TABLE [dbo].[CandidateTrainings] CHECK CONSTRAINT [FK_CandidateTrainings_CandidateId]


END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateEmploymentDetails]') AND type in (N'U'))
BEGIN


	CREATE TABLE [dbo].[CandidateEmploymentDetails](
		[CandidateEmploymentDetailsId] [int] IDENTITY(1,1) NOT NULL,
		[CandidateId] [int] NOT NULL,
		[OrganizationName] [nvarchar](50) NOT NULL,
		[OrganizationLocation] [nvarchar](50) NOT NULL,
		[Designation] [nvarchar](50) NOT NULL,
		[EmployeeCode] [nvarchar](50) NOT NULL,
		[HumanResourceName] [nvarchar](50) NOT NULL,
		[HumanResourceDesignation] [nvarchar](50) NOT NULL,
		[HumanResourceContact] [nvarchar](50) NOT NULL,
		[EmploymentStartDate] [nvarchar](50) NOT NULL,
		[EmploymentEndDate] [nvarchar](50) NOT NULL,
		[AnnualCompensation] [decimal](18, 2) NOT NULL,
		[ReasonToLeave] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_CandidateEmploymentDetails] PRIMARY KEY CLUSTERED 
	(
		[CandidateEmploymentDetailsId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[CandidateEmploymentDetails]  WITH CHECK ADD  CONSTRAINT [FK_CandidateEmploymentDetails_CandidateID] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])

	ALTER TABLE [dbo].[CandidateEmploymentDetails] CHECK CONSTRAINT [FK_CandidateEmploymentDetails_CandidateID]

END
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateReferences]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[CandidateReferences](
		[CandidateReferencesId] [int] IDENTITY(1,1) NOT NULL,
		[CandidateId] [int] NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Duration] [nvarchar](50) NULL,
		[Designation] [nvarchar](50) NULL,
		[Organization] [nvarchar](50) NULL,
		[Email] [nvarchar](50) NULL,
		[Mobile] [nvarchar](50) NULL,
		[AlternateNumber] [nvarchar](50) NULL,
		CONSTRAINT [PK_CandidateReferences] PRIMARY KEY CLUSTERED 
	(
		[CandidateReferencesId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]



	ALTER TABLE [dbo].[CandidateReferences]  WITH CHECK ADD  CONSTRAINT [FK_CandidateReferences_CandidateId] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])


	ALTER TABLE [dbo].[CandidateReferences] CHECK CONSTRAINT [FK_CandidateReferences_CandidateId]

END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateAddtionalDetails]') AND type in (N'U'))
BEGIN

	CREATE TABLE [dbo].[CandidateAddtionalDetails](
		[CandidateAddtionalDetailsId] [int] IDENTITY(1,1) NOT NULL,
		[CandidateId] [int] NOT NULL,
		[VisaDenial] bit NOT NULL,
		[VisaDenialDetails] [nvarchar](100) NULL,
		[OverseasAssignment] bit NOT NULL,
		[OverseasAssignmentDetails] [nvarchar](100) NULL,
		[EmidsFriendsRelatives] bit NOT NULL,
		[EmidsFriendsRelativesDetails] [nvarchar](100) NULL,
		[Illness] bit NOT NULL,
		[IllnessDetails] [nvarchar](100) NULL,		
		[Prosecution] bit NOT NULL,
		[ProsecutionDetails] [nvarchar](100) NULL,		
		[OtherEmployerCommittment] bit NOT NULL,
		[OtherEmployerCommittmentDetails] [nvarchar](100) NULL,		
		[TravelAbroad] bit NOT NULL,
		[TravelAbroadDetails] [nvarchar](50) NULL,		
		[TravelAbroadDuration] [nvarchar](50) NULL,
		CONSTRAINT [PK_CandidateAddtionalDetails] PRIMARY KEY CLUSTERED 
	(
		[CandidateAddtionalDetailsId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]



	ALTER TABLE [dbo].[CandidateAddtionalDetails]  WITH CHECK ADD  CONSTRAINT [FK_CandidateAddtionalDetails_CandidateId] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([CandidateId])


	ALTER TABLE [dbo].[CandidateAddtionalDetails] CHECK CONSTRAINT [FK_CandidateAddtionalDetails_CandidateId]

END
GO



--IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[CandidateEmoluments]') AND type in (N'U'))
--BEGIN

--	CREATE TABLE [dbo].[CandidateEmoluments](
--		[CandidateEmolumentsId] [int] IDENTITY(1,1) NOT NULL,
--		[CandidateId] [int] NOT NULL,
--		[Basic] [decimal](18, 0) NOT NULL,
--		[HRA] [decimal](18, 0) NOT NULL,
--		[Allowances] [decimal] (18, 0) NOT NULL,
--		[FixedOthers] [decimal](18, 0) NOT NULL,
--		[Medical] [decimal](18, 0) NOT NULL,
--		[Food] [decimal](18, 0) NOT NULL,
--		[LTA] [decimal](18, 0) NOT NULL,
--		[VariableOthers] [decimal](18, 0) NOT NULL,
--		[PF] [decimal](18, 0) NOT NULL,
--		[MonthlyGross] [decimal](18, 0) NOT NULL,
--		[AnnualGross] [decimal](18, 0) NOT NULL,
--	 CONSTRAINT [PK_CandidateEmoluments] PRIMARY KEY CLUSTERED 
--	(
--		[CandidateEmolumentsId] ASC
--	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--	) ON [PRIMARY]



--	ALTER TABLE [dbo].[CandidateEmoluments]  WITH CHECK ADD  CONSTRAINT [FK_CandidateEmoluments_CandidateId] FOREIGN KEY([CandidateId])
--	REFERENCES [dbo].[Candidate] ([CandidateId])


--	ALTER TABLE [dbo].[CandidateEmoluments] CHECK CONSTRAINT [FK_CandidateEmoluments_CandidateId]

--END
--GO
