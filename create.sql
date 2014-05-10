USE [careertools]
GO

/****** Object:  Table [careertools].[Company]    Script Date: 5/10/2014 11:57:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
/***************************************** COMPANY ***************************************/
CREATE TABLE [careertools].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[UserID]  [nvarchar](128) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

/************************************** CONTACT TYPE **************************************/

CREATE TABLE [careertools].[ContactType](
	[ContactTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ContactTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[ContactTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [careertools].[ContactType]
           ([ContactTypeName])
     VALUES
           ('Applied for Job'),
           ('Recuiter Contact'),
           ('Recruiter Question'),
           ('Notification of Submittal'),
           ('Request for Phone Screen'),
           ('Request for In Person Interview'),
           ('Phone Screen Scheduled'),
           ('In Person Interview Scheduled'),
           ('Feedback from Phone Screen'),
           ('Feedback from In Person Interview'),
           ('Offer Made'),
           ('Offer Not Made'),
           ('Applicant Denied Offer')
GO


/************************************ RECRUITING COMPANY  *****************************************/
CREATE TABLE [careertools].[RecruitingCompany](
	[RecruitingCompanyID] [int] IDENTITY(1,1) NOT NULL,
	[UserID]  [nvarchar](128) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RecruitingCompany] PRIMARY KEY CLUSTERED 
(
	[RecruitingCompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [careertools].[Refer](
	[ReferID] [int] IDENTITY(1,1) NOT NULL,
	[UserID]  [nvarchar](128) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Refer] PRIMARY KEY CLUSTERED 
(
	[ReferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/**************************************** STAGE *****************************************/

CREATE TABLE [careertools].[Stage](
	[StageID] [int] IDENTITY(1,1) NOT NULL,
	[StageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED 
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [careertools].[Stage]
           ([StageName])
     VALUES
           ('Applied for Position'),
		   ('Application Acknowledged'),
		   ('Recruiter Submitted'),
		   ('Phone Screen'),
		   ('In Person Interview'),
		   ('Pending Feedback'),
		   ('Pending Offer'),
		   ('Offer Declined')
GO



/**************************************** TERM ******************************************/

CREATE TABLE [careertools].[Term](
	[TermId] [int] IDENTITY(1,1) NOT NULL,
	[TermName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Term] PRIMARY KEY CLUSTERED 
(
	[TermId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [careertools].[Term]
           ([TermName])
     VALUES
           ('Contract - Corp to Corp'),
           ('Contract - Independent'),
           ('Contract - W2'),
           ('Contract to Hire'),
           ('Full Time'),
           ('Part Time')
 GO

/***************************************** CONTACT ***************************************/
CREATE TABLE [careertools].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[UserID]  [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[RecruitingCompanyFK] [int] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [careertools].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_RecruitingCompany] FOREIGN KEY([RecruitingCompanyFK])
REFERENCES [careertools].[RecruitingCompany] ([RecruitingCompanyID])
GO

ALTER TABLE [careertools].[Contact] CHECK CONSTRAINT [FK_Contact_RecruitingCompany]
GO


/**************************************** JOB *******************************************/
CREATE TABLE [careertools].[Job](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[UserID]  [nvarchar](128) NOT NULL,
	[JobTitle] [nvarchar](50) NOT NULL,
	[Company] [int] NOT NULL,
	[ReferType] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[TermFK] [int] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [careertools].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Company] FOREIGN KEY([Company])
REFERENCES [careertools].[Company] ([CompanyID])
GO

ALTER TABLE [careertools].[Job] CHECK CONSTRAINT [FK_Job_Company]
GO

ALTER TABLE [careertools].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Refer] FOREIGN KEY([ReferType])
REFERENCES [careertools].[Refer] ([ReferID])
GO

ALTER TABLE [careertools].[Job] CHECK CONSTRAINT [FK_Job_Refer]
GO

ALTER TABLE [careertools].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Term] FOREIGN KEY([TermFK])
REFERENCES [careertools].[Term] ([TermId])
GO

ALTER TABLE [careertools].[Job] CHECK CONSTRAINT [FK_Job_Term]
GO

/**************************************** EVENT *****************************************/

CREATE TABLE [careertools].[Event](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[UserID]  [nvarchar](128) NOT NULL,
	[ContactFK] [int] NOT NULL,
	[JobFK] [int] NOT NULL,
	[TypeFK] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[StageFK] [int] NOT NULL,
	[Notes] [text] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [careertools].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Contact] FOREIGN KEY([ContactFK])
REFERENCES [careertools].[Contact] ([ContactID])
GO

ALTER TABLE [careertools].[Event] CHECK CONSTRAINT [FK_Event_Contact]
GO

ALTER TABLE [careertools].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_ContactType] FOREIGN KEY([ContactFK])
REFERENCES [careertools].[ContactType] ([ContactTypeID])
GO

ALTER TABLE [careertools].[Event] CHECK CONSTRAINT [FK_Event_ContactType]
GO

ALTER TABLE [careertools].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Job] FOREIGN KEY([JobFK])
REFERENCES [careertools].[Job] ([JobID])
GO

ALTER TABLE [careertools].[Event] CHECK CONSTRAINT [FK_Event_Job]
GO

ALTER TABLE [careertools].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Stage] FOREIGN KEY([StageFK])
REFERENCES [careertools].[Stage] ([StageID])
GO

ALTER TABLE [careertools].[Event] CHECK CONSTRAINT [FK_Event_Stage]
GO


