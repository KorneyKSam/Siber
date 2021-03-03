USE [DBSibers]
GO
/****** Object: Table [dbo].[__EFMigrationsHistory] Script Date: 03.03.2021 20:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
[MigrationId] [nvarchar](150) NOT NULL,
[ProductVersion] [nvarchar](32) NOT NULL,
CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED
(
[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: Table [dbo].[CustomerCompanies] Script Date: 03.03.2021 20:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCompanies](
[Id] [bigint] IDENTITY(1,1) NOT NULL,
[CompanyName] [nvarchar](50) NOT NULL,
[Description] [nvarchar](250) NULL,
CONSTRAINT [PK_CustomerCompanies] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: Table [dbo].[EmployeeProject] Script Date: 03.03.2021 20:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProject](
[EmployeeID] [bigint] NOT NULL,
[ProjectID] [bigint] NOT NULL,
[DateTimeOfCreation] [datetime] NOT NULL,
CONSTRAINT [PK_ProjectExecutors] PRIMARY KEY CLUSTERED
(
[EmployeeID] ASC,
[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: Table [dbo].[Employees] Script Date: 03.03.2021 20:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
[Id] [bigint] IDENTITY(1,1) NOT NULL,
[LastName] [nvarchar](50) NOT NULL,
[FirstName] [nvarchar](50) NOT NULL,
[MiddleName] [nvarchar](50) NULL,
[Email] [varchar](50) NOT NULL,
[Company] [bigint] NOT NULL,
[DateTimeOfCreation] [datetime] NOT NULL,
CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: Table [dbo].[ExecutingCompanies] Script Date: 03.03.2021 20:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutingCompanies](
[Id] [bigint] IDENTITY(1,1) NOT NULL,
[CompanyName] [nvarchar](50) NOT NULL,
[Description] [nvarchar](250) NULL,
CONSTRAINT [PK_ExecutingCompanies] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: Table [dbo].[Projects] Script Date: 03.03.2021 20:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
[Id] [bigint] IDENTITY(1,1) NOT NULL,
[ProjectName] [nvarchar](50) NOT NULL,
[CustomerCompanyID] [bigint] NOT NULL,
[ExecutingCompanyID] [bigint] NOT NULL,
[ProjectPriority] [int] NOT NULL,
[StartDate] [date] NOT NULL,
[EndDate] [date] NOT NULL,
[ProjectLeaderID] [bigint] NOT NULL,
[DateTimeOfCreation] [datetime] NOT NULL,
CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: Table [dbo].[User] Script Date: 03.03.2021 20:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
[Id] [bigint] IDENTITY(1,1) NOT NULL,
[Email] [varchar](50) NOT NULL,
[Login] [nvarchar](50) NOT NULL,
[Password] [nvarchar](50) NOT NULL,
[DisplayName] [nvarchar](50) NOT NULL,
CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE
 
[dbo].[EmployeeProject] WITH CHECK ADD CONSTRAINT [FK_ProjectExecutors_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_ProjectExecutors_Employees]
GO
ALTER TABLE [dbo].[EmployeeProject] WITH CHECK ADD CONSTRAINT [FK_ProjectExecutors_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_ProjectExecutors_Projects]
GO
ALTER TABLE [dbo].[Employees] WITH CHECK ADD CONSTRAINT [FK_Employee_ExecutingCompany] FOREIGN KEY([Company])
REFERENCES [dbo].[ExecutingCompanies] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employee_ExecutingCompany]
GO
ALTER TABLE [dbo].[Projects] WITH CHECK ADD CONSTRAINT [FK_Projects_CustomerCompanies] FOREIGN KEY([CustomerCompanyID])
REFERENCES [dbo].[CustomerCompanies] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_CustomerCompanies]
GO
ALTER TABLE [dbo].[Projects] WITH CHECK ADD CONSTRAINT [FK_Projects_Employees] FOREIGN KEY([ProjectLeaderID])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Employees]
GO
ALTER TABLE [dbo].[Projects] WITH CHECK ADD CONSTRAINT [FK_Projects_ExecutingCompanies] FOREIGN KEY([ExecutingCompanyID])
REFERENCES [dbo].[ExecutingCompanies] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ExecutingCompanies]
GO

Insert into [dbo].[User] values('test@mail.ru', 'test', 'test', 'test')
Insert into [dbo].[CustomerCompanies] values('��������','')
Insert into [dbo].[CustomerCompanies] values('�������','')
Insert into [dbo].[CustomerCompanies] values('����������','')
Insert into [dbo].[CustomerCompanies] values('��������','')
Insert into [dbo].[CustomerCompanies] values('����������','')
Insert into [dbo].[CustomerCompanies] values('����� ��','���� �������������')

Insert into [dbo].[ExecutingCompanies] values('Microsoft','���������� ����������������� ��������')
Insert into [dbo].[ExecutingCompanies] values('Google','������������ ����������������� ����������')
Insert into [dbo].[ExecutingCompanies] values('IBM','������������� � ��������� ����������� � ������������ �����������')
Insert into [dbo].[ExecutingCompanies] values('Cisco','������������ ����������������� ��������, ��������������� � ��������� ������� ������������')
Insert into [dbo].[ExecutingCompanies] values('Amazon','������������ ��������, ���������� � ���� �� ������ �������� ����������� ��������� � ��������-�������� ���������� �� ������� � �������� �������������.')
Insert into [dbo].[ExecutingCompanies] values('Sibers','�������� ������� ������������� ��������� � ���-���������� ��� ����������� ����������.')
Insert into [dbo].[ExecutingCompanies] values('Del','������������ ��, �������� ����������')
Insert into [dbo].[ExecutingCompanies] values('Accenture','������-����������������, ���������, ����������, ��������.')
Insert into [dbo].[ExecutingCompanies] values('Oracle','������������� ��, �������� ����������������.')
Insert into [dbo].[ExecutingCompanies] values('Fujitsu','��, IT ������ � ����������������, ����������������.')
Insert into [dbo].[ExecutingCompanies] values('Tech Data','����������, ��, IT ����������������.')

Insert into [dbo].[Employees] values('��������','���������','����������','Felix@.mail.com','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','������','��������','Modest@mail.com','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','������','���������','Shestak23@gmail.com','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('�������','�������','���������','Yakov@mail.ru','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','���������','��������','Lizy@mail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','�����','�������','Beta@gmail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','������������','�������������','Rost@.mail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('�������','�������','��������','Frol@.mail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','������','����������','Komar@mail.ru','3','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','��������','���������','Sozon@mail.com','3','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('����������','����','�����������','Aid@gmail.com','4','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('�������','�����','���������','David@.mail.com','4','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('�����','�������','��������','Arpav@.mail.com','5','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('������','�����','��������','Max@mail.ru','5','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('������','�������','���������','Tim@mail.com','6','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('�������','��������','���������','Iosif@gmail.com','6','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('����������','��������','����������','Kondrad@.mail.com','10','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('����','������','����������','German@.mail.com','7','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('������','�������','���������','Roxi@gmail.com','7','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('���������','����','����������','Gabi@.mail.com','8','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('�������','�����','�����������','IlonMask@.mail.com','9','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('������','��������','����������','Platon@.mail.com','10','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('�������','�����','���������','LDan@.mail.com','10','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('������','�����','�������������','Zolton@.mail.com','11','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('��������','�������','��������','Kirillov@.mail.com','11','2021-03-03 15:32:28.000')

Insert into [dbo].[Projects] values('Project�1','1','1','1','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '1','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�2','2','2','2','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '5','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�3','3','3','3','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '9','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�4','4','4','4','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '11','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�5','5','5','5','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '13','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�6','6','6','4','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '15','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�7','1','7','3','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '18','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�8','2','8','2','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '20','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�9','3','9','1','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '21','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�10','4','10','2','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '23','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project�11','5','11','3','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '24','2021-03-03 15:32:28.000')