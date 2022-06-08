USE [master]
GO
/****** Object:  Database [EduPortal]    Script Date: 6/3/2022 7:12:05 PM ******/
CREATE DATABASE [EduPortal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EduPortal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EduPortal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EduPortal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EduPortal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EduPortal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EduPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EduPortal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EduPortal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EduPortal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EduPortal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EduPortal] SET ARITHABORT OFF 
GO
ALTER DATABASE [EduPortal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EduPortal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EduPortal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EduPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EduPortal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EduPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EduPortal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EduPortal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EduPortal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EduPortal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EduPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EduPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EduPortal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EduPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EduPortal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EduPortal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EduPortal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EduPortal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EduPortal] SET  MULTI_USER 
GO
ALTER DATABASE [EduPortal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EduPortal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EduPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EduPortal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EduPortal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EduPortal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EduPortal] SET QUERY_STORE = OFF
GO
USE [EduPortal]
GO
/****** Object:  Table [dbo].[ChatGroup]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatGroup](
	[ChatGroupID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedAt] [datetime] NULL,
	[LastActive] [datetime] NULL,
	[LastMassage] [nvarchar](500) NULL,
	[SessionID] [int] NULL,
 CONSTRAINT [PK_ChatGroup] PRIMARY KEY CLUSTERED 
(
	[ChatGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chats]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chats](
	[ChatsID] [int] IDENTITY(1,1) NOT NULL,
	[ChatGroupID] [int] NULL,
	[MessageID] [int] NULL,
 CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED 
(
	[ChatsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collage]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collage](
	[CollageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[ArabicName] [varchar](100) NULL,
 CONSTRAINT [PK_Collage] PRIMARY KEY CLUSTERED 
(
	[CollageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[ArabicName] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[ArabicDescription] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedHour] [int] NULL,
	[PassMark] [int] NULL,
	[SpectializationID] [int] NULL,
	[CourseAssociatedID] [int] NULL,
	[Image] [varchar](max) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[StartDateandTime] [datetime] NULL,
	[EndDateandTime] [datetime] NULL,
	[Mark] [int] NULL,
	[PassMark] [int] NULL,
	[SumOfQuestion] [int] NULL,
	[Weight] [int] NULL,
	[CourseID] [int] NULL,
	[Title] [varchar](500) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamQuestion]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamQuestion](
	[ExamQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[ExamID] [int] NULL,
	[QuestionID] [int] NULL,
 CONSTRAINT [PK_ExamQuestion] PRIMARY KEY CLUSTERED 
(
	[ExamQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goals]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goals](
	[GoalsId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[ArabicTitle] [varchar](150) NULL,
	[Description] [varchar](150) NULL,
	[ArabicDescription] [varchar](150) NULL,
	[CourseID] [int] NULL,
 CONSTRAINT [PK_Goals] PRIMARY KEY CLUSTERED 
(
	[GoalsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[IsLogin] [bit] NULL,
	[LastLogin] [datetime] NULL,
	[LastLogout] [datetime] NULL,
	[UniversityId] [bigint] NOT NULL,
	[ConnectionString] [varchar](max) NULL,
	[IsConnectionActive] [bit] NULL,
	[TeacherID] [int] NULL,
	[StudentID] [int] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[MaterialID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[Description] [varchar](150) NULL,
	[FilePath] [varchar](max) NULL,
	[UploadedAT] [datetime] NULL,
	[SessionID] [int] NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[AttachedImage] [varchar](max) NULL,
	[AttachedVideo] [varchar](max) NULL,
	[AttachedFile] [varchar](max) NULL,
	[MassageDate] [datetime] NULL,
	[SenderName] [varchar](max) NULL,
	[IsSendByTeacher] [bit] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metting]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metting](
	[MettingID] [int] IDENTITY(1,1) NOT NULL,
	[Link] [varchar](max) NULL,
	[SessionID] [int] NULL,
 CONSTRAINT [PK_Metting] PRIMARY KEY CLUSTERED 
(
	[MettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[OptionID] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [varchar](max) NULL,
	[IsCorrect] [bit] NULL,
	[QuestionID] [int] NULL,
 CONSTRAINT [PK_Option] PRIMARY KEY CLUSTERED 
(
	[OptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreRequest]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreRequest](
	[PreRequestID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NULL,
	[PrevouisCourseID] [int] NULL,
 CONSTRAINT [PK_PreRequest] PRIMARY KEY CLUSTERED 
(
	[PreRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[QuestionTypeID] [int] NULL,
	[TeacherID] [int] NULL,
	[Image] [varchar](500) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[QuestionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_QuestionType] PRIMARY KEY CLUSTERED 
(
	[QuestionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[DayPerEachWeek] [int] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[StartAt] [date] NULL,
	[EndAt] [date] NULL,
	[LectureStartTime] [time](7) NULL,
	[LectureEndTime] [time](7) NULL,
	[IsActive] [bit] NULL,
	[ScheduleID] [int] NULL,
	[CourseID] [int] NULL,
	[TeacherID] [int] NULL,
	[Image] [varchar](max) NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spectialization]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spectialization](
	[SpectializationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[ArabicName] [varchar](100) NULL,
	[Description] [varchar](max) NULL,
	[ArabicDescription] [varchar](max) NULL,
	[CollageID] [int] NULL,
 CONSTRAINT [PK_Spectialization] PRIMARY KEY CLUSTERED 
(
	[SpectializationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[ArabicName] [varchar](50) NULL,
 CONSTRAINT [PK_AcadmicStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusToDoList]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusToDoList](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_StatusToDoList] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](250) NULL,
	[JoiningDate] [date] NULL,
	[BirthDate] [date] NULL,
	[PhoneNumber] [varchar](12) NULL,
	[GPA] [float] NULL,
	[SpectializationID] [int] NULL,
	[StatusID] [int] NULL,
	[Image] [varchar](500) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAttendanceRecord]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendanceRecord](
	[StudentAttendanceRecordID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[IsAbsence] [bit] NULL,
	[Note] [nvarchar](500) NULL,
	[SessionID] [int] NULL,
	[StudentID] [int] NULL,
 CONSTRAINT [PK_StudentAttendanceRecord] PRIMARY KEY CLUSTERED 
(
	[StudentAttendanceRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentsFinishMaterial]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsFinishMaterial](
	[StudentsFinishMaterialID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialID] [int] NULL,
	[StudentID] [int] NULL,
 CONSTRAINT [PK_StudentsFinishMaterial] PRIMARY KEY CLUSTERED 
(
	[StudentsFinishMaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentsSession]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsSession](
	[StudentsSessionID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NULL,
	[StudentID] [int] NULL,
 CONSTRAINT [PK_StudentsSession] PRIMARY KEY CLUSTERED 
(
	[StudentsSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTakeExam]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTakeExam](
	[StudentTakeExamID] [int] NOT NULL,
	[StartExamAt] [datetime] NULL,
	[EndExamAt] [datetime] NULL,
	[ActualMark] [float] NULL,
	[FinalResult] [float] NULL,
	[Notes] [nvarchar](500) NULL,
	[ExamID] [int] NULL,
	[StudentID] [int] NULL,
 CONSTRAINT [PK_StudentTakeExam] PRIMARY KEY CLUSTERED 
(
	[StudentTakeExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTask]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTask](
	[StudentTaskID] [int] IDENTITY(1,1) NOT NULL,
	[ActualMark] [float] NULL,
	[FinalResult] [float] NULL,
	[Notes] [nvarchar](500) NULL,
	[TeacherResponse] [nvarchar](500) NULL,
	[StudentID] [int] NULL,
	[TaskID] [int] NULL,
	[AttactmentFile] [varchar](max) NULL,
	[SubmittedAt] [datetime] NULL,
 CONSTRAINT [PK_StudentTask] PRIMARY KEY CLUSTERED 
(
	[StudentTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[Note] [varchar](max) NULL,
	[Mark] [int] NULL,
	[Weight] [int] NULL,
	[FilePath] [varchar](max) NULL,
	[StartAt] [datetime] NULL,
	[EndAt] [datetime] NULL,
	[IsAllowLateSubmmition] [bit] NULL,
	[LastAllowedSubmmation] [datetime] NULL,
	[SessionID] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](150) NULL,
	[JobTitle] [varchar](150) NULL,
	[BirthDate] [date] NULL,
	[JoiningDate] [date] NULL,
	[Pio] [varchar](max) NULL,
	[IsActive] [nchar](10) NULL,
	[SpectializationID] [int] NULL,
	[PhoneNumber] [varchar](12) NULL,
	[Image] [varchar](500) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToDoList]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToDoList](
	[ToDoListID] [int] IDENTITY(1,1) NOT NULL,
	[TaskTitle] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[StudentID] [int] NULL,
	[TeacherID] [int] NULL,
	[StatusID] [int] NULL,
 CONSTRAINT [PK_ToDoList] PRIMARY KEY CLUSTERED 
(
	[ToDoListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 6/3/2022 7:12:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[TopicID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[ArabicTitle] [varchar](150) NULL,
	[SubTitle] [varchar](150) NULL,
	[ArabicSubTitle] [varchar](150) NULL,
	[CourseID] [int] NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[TopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Login]    Script Date: 6/3/2022 7:12:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Login] ON [dbo].[Login]
(
	[UniversityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChatGroup]  WITH CHECK ADD  CONSTRAINT [FK_ChatGroup_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([SessionID])
GO
ALTER TABLE [dbo].[ChatGroup] CHECK CONSTRAINT [FK_ChatGroup_Session]
GO
ALTER TABLE [dbo].[Chats]  WITH CHECK ADD  CONSTRAINT [FK_Chats_ChatGroup] FOREIGN KEY([ChatGroupID])
REFERENCES [dbo].[ChatGroup] ([ChatGroupID])
GO
ALTER TABLE [dbo].[Chats] CHECK CONSTRAINT [FK_Chats_ChatGroup]
GO
ALTER TABLE [dbo].[Chats]  WITH CHECK ADD  CONSTRAINT [FK_Chats_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
GO
ALTER TABLE [dbo].[Chats] CHECK CONSTRAINT [FK_Chats_Message]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Course] FOREIGN KEY([CourseAssociatedID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Course]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Spectialization] FOREIGN KEY([SpectializationID])
REFERENCES [dbo].[Spectialization] ([SpectializationID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Spectialization]
GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Course]
GO
ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_Exam] FOREIGN KEY([ExamID])
REFERENCES [dbo].[Exam] ([ExamID])
GO
ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_Exam]
GO
ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_Question]
GO
ALTER TABLE [dbo].[Goals]  WITH CHECK ADD  CONSTRAINT [FK_Goals_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Goals] CHECK CONSTRAINT [FK_Goals_Course]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Student]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Teacher]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_Material_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([SessionID])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_Material_Session]
GO
ALTER TABLE [dbo].[Metting]  WITH CHECK ADD  CONSTRAINT [FK_Metting_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([SessionID])
GO
ALTER TABLE [dbo].[Metting] CHECK CONSTRAINT [FK_Metting_Session]
GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD  CONSTRAINT [FK_Option_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Question] ([QuestionID])
GO
ALTER TABLE [dbo].[Option] CHECK CONSTRAINT [FK_Option_Question]
GO
ALTER TABLE [dbo].[PreRequest]  WITH CHECK ADD  CONSTRAINT [FK_PreRequest_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[PreRequest] CHECK CONSTRAINT [FK_PreRequest_Course]
GO
ALTER TABLE [dbo].[PreRequest]  WITH CHECK ADD  CONSTRAINT [FK_PreRequest_Course1] FOREIGN KEY([PrevouisCourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[PreRequest] CHECK CONSTRAINT [FK_PreRequest_Course1]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY([QuestionTypeID])
REFERENCES [dbo].[QuestionType] ([QuestionTypeID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuestionType]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Teacher]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Course]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Schedule]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Teacher]
GO
ALTER TABLE [dbo].[Spectialization]  WITH CHECK ADD  CONSTRAINT [FK_Spectialization_Collage] FOREIGN KEY([CollageID])
REFERENCES [dbo].[Collage] ([CollageID])
GO
ALTER TABLE [dbo].[Spectialization] CHECK CONSTRAINT [FK_Spectialization_Collage]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Spectialization] FOREIGN KEY([SpectializationID])
REFERENCES [dbo].[Spectialization] ([SpectializationID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Spectialization]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Status]
GO
ALTER TABLE [dbo].[StudentAttendanceRecord]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceRecord_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([SessionID])
GO
ALTER TABLE [dbo].[StudentAttendanceRecord] CHECK CONSTRAINT [FK_StudentAttendanceRecord_Session]
GO
ALTER TABLE [dbo].[StudentAttendanceRecord]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceRecord_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentAttendanceRecord] CHECK CONSTRAINT [FK_StudentAttendanceRecord_Student]
GO
ALTER TABLE [dbo].[StudentsFinishMaterial]  WITH CHECK ADD  CONSTRAINT [FK_StudentsFinishMaterial_Material] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Material] ([MaterialID])
GO
ALTER TABLE [dbo].[StudentsFinishMaterial] CHECK CONSTRAINT [FK_StudentsFinishMaterial_Material]
GO
ALTER TABLE [dbo].[StudentsFinishMaterial]  WITH CHECK ADD  CONSTRAINT [FK_StudentsFinishMaterial_Student] FOREIGN KEY([StudentsFinishMaterialID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentsFinishMaterial] CHECK CONSTRAINT [FK_StudentsFinishMaterial_Student]
GO
ALTER TABLE [dbo].[StudentsSession]  WITH CHECK ADD  CONSTRAINT [FK_StudentsSession_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([SessionID])
GO
ALTER TABLE [dbo].[StudentsSession] CHECK CONSTRAINT [FK_StudentsSession_Session]
GO
ALTER TABLE [dbo].[StudentsSession]  WITH CHECK ADD  CONSTRAINT [FK_StudentsSession_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentsSession] CHECK CONSTRAINT [FK_StudentsSession_Student]
GO
ALTER TABLE [dbo].[StudentTakeExam]  WITH CHECK ADD  CONSTRAINT [FK_StudentTakeExam_Exam] FOREIGN KEY([ExamID])
REFERENCES [dbo].[Exam] ([ExamID])
GO
ALTER TABLE [dbo].[StudentTakeExam] CHECK CONSTRAINT [FK_StudentTakeExam_Exam]
GO
ALTER TABLE [dbo].[StudentTakeExam]  WITH CHECK ADD  CONSTRAINT [FK_StudentTakeExam_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentTakeExam] CHECK CONSTRAINT [FK_StudentTakeExam_Student]
GO
ALTER TABLE [dbo].[StudentTask]  WITH CHECK ADD  CONSTRAINT [FK_StudentTask_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentTask] CHECK CONSTRAINT [FK_StudentTask_Student]
GO
ALTER TABLE [dbo].[StudentTask]  WITH CHECK ADD  CONSTRAINT [FK_StudentTask_StudentTask] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Task] ([TaskID])
GO
ALTER TABLE [dbo].[StudentTask] CHECK CONSTRAINT [FK_StudentTask_StudentTask]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([SessionID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Session]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Spectialization] FOREIGN KEY([SpectializationID])
REFERENCES [dbo].[Spectialization] ([SpectializationID])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Spectialization]
GO
ALTER TABLE [dbo].[ToDoList]  WITH CHECK ADD  CONSTRAINT [FK_ToDoList_StatusToDoList] FOREIGN KEY([StatusID])
REFERENCES [dbo].[StatusToDoList] ([StatusId])
GO
ALTER TABLE [dbo].[ToDoList] CHECK CONSTRAINT [FK_ToDoList_StatusToDoList]
GO
ALTER TABLE [dbo].[ToDoList]  WITH CHECK ADD  CONSTRAINT [FK_ToDoList_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[ToDoList] CHECK CONSTRAINT [FK_ToDoList_Student]
GO
ALTER TABLE [dbo].[ToDoList]  WITH CHECK ADD  CONSTRAINT [FK_ToDoList_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[ToDoList] CHECK CONSTRAINT [FK_ToDoList_Teacher]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_Course]
GO
USE [master]
GO
ALTER DATABASE [EduPortal] SET  READ_WRITE 
GO
