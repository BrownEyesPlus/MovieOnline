USE [master]
GO
/****** Object:  Database [MovieCenter2]    Script Date: 12/25/2020 5:30:03 PM ******/
CREATE DATABASE [MovieCenter2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieCenter2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MovieCenter2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieCenter2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MovieCenter2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MovieCenter2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieCenter2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieCenter2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieCenter2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieCenter2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieCenter2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieCenter2] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieCenter2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MovieCenter2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieCenter2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieCenter2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieCenter2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieCenter2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieCenter2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieCenter2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieCenter2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieCenter2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MovieCenter2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieCenter2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieCenter2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieCenter2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieCenter2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieCenter2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieCenter2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieCenter2] SET RECOVERY FULL 
GO
ALTER DATABASE [MovieCenter2] SET  MULTI_USER 
GO
ALTER DATABASE [MovieCenter2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieCenter2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieCenter2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieCenter2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MovieCenter2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieCenter2', N'ON'
GO
ALTER DATABASE [MovieCenter2] SET QUERY_STORE = OFF
GO
USE [MovieCenter2]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGiaPhim]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaPhim](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[MaPhim] [int] NULL,
	[MaUser] [int] NULL,
	[Diem] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaoDien]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaoDien](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phim]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phim](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[TenPhimTiengViet] [nvarchar](50) NULL,
	[DiemIMDb] [nvarchar](10) NULL,
	[NgayPhatHanh] [date] NULL,
	[MoTa] [ntext] NULL,
	[AnhMoi] [nvarchar](500) NULL,
	[ThoiLuong] [nvarchar](25) NULL,
	[NgonNgu] [nvarchar](50) NULL,
	[DanhGiaTB] [float] NULL,
	[TenTep] [nvarchar](100) NULL,
	[MaTheLoai] [int] NULL,
	[MaDaoDien] [int] NULL,
	[MaQuocGia] [int] NULL,
	[MaDanhMuc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuocGia]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuocGia](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/25/2020 5:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[TenHienThi] [nvarchar](50) NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[TrangThaiVip] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Phim] ADD  DEFAULT ((0)) FOR [DanhGiaTB]
GO
USE [master]
GO
ALTER DATABASE [MovieCenter2] SET  READ_WRITE 
GO
