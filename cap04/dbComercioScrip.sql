USE [master]
GO
/****** Object:  Database [dbComercio]    Script Date: 27/01/2019 13:45:30 ******/
CREATE DATABASE [dbComercio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbComercio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\dbComercio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbComercio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\dbComercio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbComercio] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbComercio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbComercio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbComercio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbComercio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbComercio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbComercio] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbComercio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbComercio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbComercio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbComercio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbComercio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbComercio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbComercio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbComercio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbComercio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbComercio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbComercio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbComercio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbComercio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbComercio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbComercio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbComercio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbComercio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbComercio] SET RECOVERY FULL 
GO
ALTER DATABASE [dbComercio] SET  MULTI_USER 
GO
ALTER DATABASE [dbComercio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbComercio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbComercio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbComercio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbComercio] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbComercio', N'ON'
GO
ALTER DATABASE [dbComercio] SET QUERY_STORE = OFF
GO
USE [dbComercio]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [dbComercio]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 27/01/2019 13:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marca]    Script Date: 27/01/2019 13:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[MarcaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[MarcaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 27/01/2019 13:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[ProductoCode] [nvarchar](100) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[CategoriaID] [int] NOT NULL,
	[MarcaID] [int] NOT NULL,
	[UnidadMedidaID] [int] NOT NULL,
	[PrecioMayor] [decimal](18, 2) NOT NULL,
	[PrecioMenor] [decimal](18, 2) NOT NULL,
	[StockActual] [decimal](18, 2) NOT NULL,
	[StockMinimo] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[UsuarioCreador] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioModificador] [uniqueidentifier] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 27/01/2019 13:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadMedida](
	[UnidadMedidaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[UnidadMedidaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Mouse', NULL, 1)
INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Mouse', NULL, 1)
INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (3, N'Mouse', NULL, 1)
INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (4, N'Mouse', NULL, 1)
INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (5, N'laptop', N'hp', 0)
INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (6, N'teclado', N'barato', 0)
INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (7, N'mouse', N'razer', 0)
INSERT [dbo].[Categoria] ([CategoriaID], [Nombre], [Descripcion], [Estado]) VALUES (8, N'mouses', N'razer3', 0)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([MarcaID])
REFERENCES [dbo].[Marca] ([MarcaID])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Marca]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_UnidadMedida] FOREIGN KEY([UnidadMedidaID])
REFERENCES [dbo].[UnidadMedida] ([UnidadMedidaID])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_UnidadMedida]
GO
USE [master]
GO
ALTER DATABASE [dbComercio] SET  READ_WRITE 
GO
