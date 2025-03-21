USE [master]
GO
/****** Object:  Database [ItlaTvDB]    Script Date: 9/2/2025 11:11:02 p. m. ******/
CREATE DATABASE [ItlaTvDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ItlaTvDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ItlaTvDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ItlaTvDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ItlaTvDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ItlaTvDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ItlaTvDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ItlaTvDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ItlaTvDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ItlaTvDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ItlaTvDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ItlaTvDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ItlaTvDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ItlaTvDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ItlaTvDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ItlaTvDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ItlaTvDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ItlaTvDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ItlaTvDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ItlaTvDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ItlaTvDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ItlaTvDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ItlaTvDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ItlaTvDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ItlaTvDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ItlaTvDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ItlaTvDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ItlaTvDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ItlaTvDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ItlaTvDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ItlaTvDB] SET  MULTI_USER 
GO
ALTER DATABASE [ItlaTvDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ItlaTvDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ItlaTvDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ItlaTvDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ItlaTvDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ItlaTvDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ItlaTvDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ItlaTvDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ItlaTvDB]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 9/2/2025 11:11:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productoras]    Script Date: 9/2/2025 11:11:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productoras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 9/2/2025 11:11:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Imagen] [nvarchar](max) NOT NULL,
	[EnlaceVideo] [nvarchar](max) NOT NULL,
	[ProductoraId] [int] NOT NULL,
	[GeneroPrimarioId] [int] NOT NULL,
	[GeneroSecundarioId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Generos] ON 

INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (1, N'Acción')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (2, N'Comedia')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (3, N'Drama')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (4, N'Thriller')
INSERT [dbo].[Generos] ([Id], [Nombre]) VALUES (5, N'Terror')
SET IDENTITY_INSERT [dbo].[Generos] OFF
GO
SET IDENTITY_INSERT [dbo].[Productoras] ON 

INSERT [dbo].[Productoras] ([Id], [Nombre]) VALUES (1, N'Netflix')
INSERT [dbo].[Productoras] ([Id], [Nombre]) VALUES (2, N'HBO')
INSERT [dbo].[Productoras] ([Id], [Nombre]) VALUES (3, N'Disney+')
SET IDENTITY_INSERT [dbo].[Productoras] OFF
GO
SET IDENTITY_INSERT [dbo].[Series] ON 

INSERT [dbo].[Series] ([Id], [Nombre], [Imagen], [EnlaceVideo], [ProductoraId], [GeneroPrimarioId], [GeneroSecundarioId]) VALUES (1, N'Stranger Things', N'https://loyolamaroon.com/wp-content/uploads/2022/08/ST-Poster-Season-4-720x900.jpeg', N'https://www.youtube.com/watch?v=a3thyAnShck', 1, 1, 3)
INSERT [dbo].[Series] ([Id], [Nombre], [Imagen], [EnlaceVideo], [ProductoraId], [GeneroPrimarioId], [GeneroSecundarioId]) VALUES (2, N'Game of Thrones', N'https://mediaproxy.tvtropes.org/width/1200/https://static.tvtropes.org/pmwiki/pub/images/gotposterbig.png', N'https://www.youtube.com/watch?v=KPLWWIOCOOQ', 2, 3, NULL)
INSERT [dbo].[Series] ([Id], [Nombre], [Imagen], [EnlaceVideo], [ProductoraId], [GeneroPrimarioId], [GeneroSecundarioId]) VALUES (3, N'The Mandalorian', N'https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/EC2C0BDB735FB6AC6184366741E496BFC66F34FF1A7F24E72DB607E427C47B4C/scale?width=506&aspectRatio=2.00&format=webp', N'https://www.youtube.com/watch?v=aOC8E8z_ifw', 3, 1, 2)
INSERT [dbo].[Series] ([Id], [Nombre], [Imagen], [EnlaceVideo], [ProductoraId], [GeneroPrimarioId], [GeneroSecundarioId]) VALUES (6, N'Avengers End Game', N'https://es.web.img2.acsta.net/pictures/19/03/26/17/22/0896830.jpg', N'https://www.youtube.com/watch?v=TcMBFSGVi1c', 3, 1, 2)
SET IDENTITY_INSERT [dbo].[Series] OFF
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD FOREIGN KEY([GeneroPrimarioId])
REFERENCES [dbo].[Generos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD FOREIGN KEY([GeneroSecundarioId])
REFERENCES [dbo].[Generos] ([Id])
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD FOREIGN KEY([ProductoraId])
REFERENCES [dbo].[Productoras] ([Id])
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [ItlaTvDB] SET  READ_WRITE 
GO
