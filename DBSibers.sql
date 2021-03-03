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
Insert into [dbo].[CustomerCompanies] values('Роснефть','')
Insert into [dbo].[CustomerCompanies] values('Газпром','')
Insert into [dbo].[CustomerCompanies] values('Транснефть','')
Insert into [dbo].[CustomerCompanies] values('Роснефть','')
Insert into [dbo].[CustomerCompanies] values('Северсталь','')
Insert into [dbo].[CustomerCompanies] values('Мария Ра','Сеть супермаркетов')

Insert into [dbo].[ExecutingCompanies] values('Microsoft','Крупнейшая транснациональная компания')
Insert into [dbo].[ExecutingCompanies] values('Google','Американская транснациональная корпорация')
Insert into [dbo].[ExecutingCompanies] values('IBM','Производитель и поставщик аппаратного и программного обеспечения')
Insert into [dbo].[ExecutingCompanies] values('Cisco','Американская транснациональная компания, разрабатывающая и продающая сетевое оборудование')
Insert into [dbo].[ExecutingCompanies] values('Amazon','Американская компания, крупнейшая в мире на рынках платформ электронной коммерции и публично-облачных вычислений по выручке и рыночной капитализации.')
Insert into [dbo].[ExecutingCompanies] values('Sibers','Компания Сайберс разрабатывает программы и веб-приложения для иностранных заказчиков.')
Insert into [dbo].[ExecutingCompanies] values('Del','Компьютерное ПО, облачные вычисления')
Insert into [dbo].[ExecutingCompanies] values('Accenture','Бизнес-консультирование, стратегия, технология, процессы.')
Insert into [dbo].[ExecutingCompanies] values('Oracle','Корпоративное ПО, облачное программирование.')
Insert into [dbo].[ExecutingCompanies] values('Fujitsu','ПО, IT услуги и консультирование, телекоммуникации.')
Insert into [dbo].[ExecutingCompanies] values('Tech Data','Технологии, ПО, IT консультирование.')

Insert into [dbo].[Employees] values('Игнатьев','Панкратий','Феликсович','Felix@.mail.com','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Муравьёв','Модест','Иванович','Modest@mail.com','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Шестаков','Модест','Ильянович','Shestak23@gmail.com','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Селезнёв','Велорий','Яковлевич','Yakov@mail.ru','1','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Лазарева','Елизавета','Евсеевна','Lizy@mail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Ефремова','Берта','Юрьевна','Beta@gmail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Смирнова','Александрина','Ростиславовна','Rost@.mail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Наумова','Наталия','Фроловна','Frol@.mail.com','2','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Комарова','Ксения','Степановна','Komar@mail.ru','3','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Смирнова','Северина','Созоновна','Sozon@mail.com','3','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Евдокимова','Аида','Куприяновна','Aid@gmail.com','4','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Данилов','Борис','Давидович','David@.mail.com','4','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Ильин','Арнольд','Павлович','Arpav@.mail.com','5','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Иванов','Тарас','Максович','Max@mail.ru','5','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Блохин','Альфред','Тимурович','Tim@mail.com','6','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Устинов','Афанасий','Иосифович','Iosif@gmail.com','6','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Кондратьев','Геннадий','Михаилович','Kondrad@.mail.com','10','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Юдин','Эрнест','Германович','German@.mail.com','7','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Бурова','Роксана','Макаровна','Roxi@gmail.com','7','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Стрелкова','Габи','Максимовна','Gabi@.mail.com','8','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Иванова','Илона','Альбертовна','IlonMask@.mail.com','9','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Хохлов','Бенедикт','Платонович','Platon@.mail.com','10','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Данилов','Денис','Филипович','LDan@.mail.com','10','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Золтон','Хивай','Краснолюдович','Zolton@.mail.com','11','2021-03-03 15:32:28.000')
Insert into [dbo].[Employees] values('Кириллов','Рудольф','Иванович','Kirillov@.mail.com','11','2021-03-03 15:32:28.000')

Insert into [dbo].[Projects] values('Project№1','1','1','1','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '1','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№2','2','2','2','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '5','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№3','3','3','3','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '9','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№4','4','4','4','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '11','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№5','5','5','5','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '13','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№6','6','6','4','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '15','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№7','1','7','3','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '18','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№8','2','8','2','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '20','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№9','3','9','1','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '21','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№10','4','10','2','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '23','2021-03-03 15:32:28.000')
Insert into [dbo].[Projects] values('Project№11','5','11','3','2021-03-03 15:32:28.000','2021-04-03 15:32:28.000', '24','2021-03-03 15:32:28.000')