USE [Vuz]
GO
/****** Object:  Table [dbo].[AcademicRanks]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicRanks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AcademicRanks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FacultyId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostGraduate]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostGraduate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_PostGraduate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScientificDirections]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScientificDirections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DirectionName] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_ScientificDirections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScientificTopics]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScientificTopics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_ScientificTopics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](150) NOT NULL,
	[GroupId] [int] NOT NULL,
	[Children] [int] NULL,
	[GenderId] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[StipendReason] [nvarchar](max) NULL,
	[StipendSize] [int] NULL,
	[FacultyId] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](150) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[AcademicRanksId] [int] NOT NULL,
	[CountChildren] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[Salary] [int] NOT NULL,
	[Aspirant] [nchar](10) NOT NULL,
	[ScWordks] [nvarchar](max) NOT NULL,
	[ScTopicsId] [int] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/22/2023 5:14:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Id_Role] [int] NOT NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_Department]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Department]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([Id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Faculty]
GO
ALTER TABLE [dbo].[PostGraduate]  WITH CHECK ADD  CONSTRAINT [FK_PostGraduate_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[PostGraduate] CHECK CONSTRAINT [FK_PostGraduate_Department]
GO
ALTER TABLE [dbo].[ScientificDirections]  WITH CHECK ADD  CONSTRAINT [FK_ScientificDirections_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([Id])
GO
ALTER TABLE [dbo].[ScientificDirections] CHECK CONSTRAINT [FK_ScientificDirections_Faculty]
GO
ALTER TABLE [dbo].[ScientificDirections]  WITH CHECK ADD  CONSTRAINT [FK_ScientificDirections_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[ScientificDirections] CHECK CONSTRAINT [FK_ScientificDirections_Teachers]
GO
ALTER TABLE [dbo].[ScientificTopics]  WITH CHECK ADD  CONSTRAINT [FK_ScientificTopics_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[ScientificTopics] CHECK CONSTRAINT [FK_ScientificTopics_Department]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculty] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculty]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Gender]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_AcademicRanks] FOREIGN KEY([AcademicRanksId])
REFERENCES [dbo].[AcademicRanks] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_AcademicRanks]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Department]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Gender]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_ScientificTopics] FOREIGN KEY([ScTopicsId])
REFERENCES [dbo].[ScientificTopics] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_ScientificTopics]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
