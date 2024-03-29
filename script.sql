USE [master]
GO
/****** Object:  Database [QuanLyBanHang]    Script Date: 6/11/2019 1:30:45 AM ******/
CREATE DATABASE [QuanLyBanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QuanLyBanHang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyBanHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QuanLyBanHang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyBanHang] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyBanHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanHang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyBanHang] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyBanHang', N'ON'
GO
ALTER DATABASE [QuanLyBanHang] SET QUERY_STORE = OFF
GO
USE [QuanLyBanHang]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/11/2019 1:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Bill_ID] [varchar](50) NOT NULL,
	[CustomerName] [nvarchar](255) NULL,
	[Created_at] [datetime] NULL,
	[Total] [varchar](50) NULL,
	[TrangThai] [nvarchar](255) NULL,
	[CouponID] [varchar](50) NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Bill_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 6/11/2019 1:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[Bill_ID] [varchar](50) NOT NULL,
	[ProductID] [nchar](10) NOT NULL,
	[Qty] [int] NULL,
 CONSTRAINT [PK_BillInfo] PRIMARY KEY CLUSTERED 
(
	[Bill_ID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/11/2019 1:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [nvarchar](50) NOT NULL,
	[Name] [nchar](255) NULL,
	[isDeleted] [varchar](2) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 6/11/2019 1:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon](
	[CouponID] [varchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[PhanTram] [int] NULL,
 CONSTRAINT [PK_Coupon] PRIMARY KEY CLUSTERED 
(
	[CouponID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/11/2019 1:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [nchar](10) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[CategoryID] [nvarchar](50) NULL,
	[Cost] [nvarchar](50) NULL,
	[isDeleted] [varchar](2) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/11/2019 1:30:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bill] ([Bill_ID], [CustomerName], [Created_at], [Total], [TrangThai], [CouponID]) VALUES (N'HD001', N'Nguyen Quang Huong', CAST(N'2019-06-10T00:00:00.000' AS DateTime), N'10500000', N'GOOD', N'SALE50')
INSERT [dbo].[Bill] ([Bill_ID], [CustomerName], [Created_at], [Total], [TrangThai], [CouponID]) VALUES (N'HD003', N'Quang Huong ', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'2000000', N'OK', NULL)
INSERT [dbo].[Bill] ([Bill_ID], [CustomerName], [Created_at], [Total], [TrangThai], [CouponID]) VALUES (N'HD004', N'Huong NQ', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'4000000', N'OK', N'SALE50')
INSERT [dbo].[Bill] ([Bill_ID], [CustomerName], [Created_at], [Total], [TrangThai], [CouponID]) VALUES (N'HD005', N'ABC', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'15000000', N'AKC', NULL)
INSERT [dbo].[Bill] ([Bill_ID], [CustomerName], [Created_at], [Total], [TrangThai], [CouponID]) VALUES (N'HD006', N'NAM', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'50000000', N'HIGH', N'SALE50')
INSERT [dbo].[Bill] ([Bill_ID], [CustomerName], [Created_at], [Total], [TrangThai], [CouponID]) VALUES (N'HD007', N'Nguyen Van A', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'230000000', N'OK', N'SALE50')
INSERT [dbo].[Bill] ([Bill_ID], [CustomerName], [Created_at], [Total], [TrangThai], [CouponID]) VALUES (N'HD008', N'K', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'2200000', N'FAST', NULL)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD001', N'SP001     ', 1)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD001', N'SP002     ', 1)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD003', N'SP002     ', 2)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD004', N'SP002     ', 8)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD005', N'SP002     ', 15)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD006', N'SP018     ', 5)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD007', N'SP001     ', 23)
INSERT [dbo].[BillInfo] ([Bill_ID], [ProductID], [Qty]) VALUES (N'HD008', N'SP017     ', 100)
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'8k', N'21                                                                                                                                                                                                                                                             ', N'1')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA001', N'Điện thoại                                                                                                                                                                                                                                                     ', N'0')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA002', N'Nước uống                                                                                                                                                                                                                                                      ', N'0')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA003', N'Đồ ăn                                                                                                                                                                                                                                                          ', N'0')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA004     ', N'Đồ gia dụng                                                                                                                                                                                                                                                    ', N'0')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA005     ', N'Sách                                                                                                                                                                                                                                                           ', N'0')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA006', N'Xe Đạp                                                                                                                                                                                                                                                         ', N'1')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA009', N'Máy tính bàn                                                                                                                                                                                                                                                   ', N'1')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA010', N'Laptop 1                                                                                                                                                                                                                                                       ', N'1')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA012', N'Laptop                                                                                                                                                                                                                                                         ', N'1')
INSERT [dbo].[Category] ([CategoryID], [Name], [isDeleted]) VALUES (N'MA024', N'Đàn Guitar                                                                                                                                                                                                                                                     ', N'1')
INSERT [dbo].[Coupon] ([CouponID], [SoLuong], [PhanTram]) VALUES (N'SALE50', 96, 50)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP001     ', N'IPhoneX', N'MA001', N'20000000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP002     ', N'Nokia', N'MA001', N'1000000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP003     ', N'Điện thoại bàn', N'MA001', N'100000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP004     ', N'String', N'MA002', N'10000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP005     ', N'Cocacola', N'MA002', N'8000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP006     ', N'Ô Long Tea', N'MA002', N'10000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP007     ', N'Redbull', N'MA002', N'10000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP008     ', N'Wakeup 247', N'MA002', N'10000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP009     ', N'Oishi', N'MA003', N'4000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP010     ', N'Mỳ gói Hảo Hảo', N'MA003', N'3000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP011     ', N'Sữa tươi Vinamilk', N'MA002', N'6000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP012     ', N'Đàn Guitar', N'MA004     ', N'1000000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP013     ', N'Nước rữa chén', N'MA004     ', N'10000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP014     ', N'Bột giặt', N'MA004     ', N'10000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP016     ', N'Doraemon', N'MA005', N'24000', N'0', 100)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP017     ', N'Conan', N'MA005     ', N'22000', N'0', 900)
INSERT [dbo].[Product] ([ProductID], [Name], [CategoryID], [Cost], [isDeleted], [Quantity]) VALUES (N'SP018     ', N'GalaxyS10', N'MA001', N'20000000', N'0', 20)
INSERT [dbo].[User] ([Username], [Password], [Role]) VALUES (N'admin', N'admin', 1)
INSERT [dbo].[User] ([Username], [Password], [Role]) VALUES (N'huongnq', N'12345', 1)
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Coupon] FOREIGN KEY([CouponID])
REFERENCES [dbo].[Coupon] ([CouponID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Coupon]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK_BillInfo_Bill] FOREIGN KEY([Bill_ID])
REFERENCES [dbo].[Bill] ([Bill_ID])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK_BillInfo_Bill]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK_BillInfo_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK_BillInfo_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [QuanLyBanHang] SET  READ_WRITE 
GO
