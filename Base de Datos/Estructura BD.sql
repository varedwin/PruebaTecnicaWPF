USE [master]
GO
/****** Object:  Database [BDUsuarios]    Script Date: 24/05/2023 2:22:26 p. m. ******/
CREATE DATABASE [BDUsuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDUsuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BDUsuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDUsuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BDUsuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BDUsuarios] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDUsuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDUsuarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDUsuarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDUsuarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDUsuarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDUsuarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDUsuarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDUsuarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDUsuarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDUsuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDUsuarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDUsuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDUsuarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDUsuarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDUsuarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDUsuarios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDUsuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDUsuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDUsuarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDUsuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDUsuarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDUsuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDUsuarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDUsuarios] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDUsuarios] SET  MULTI_USER 
GO
ALTER DATABASE [BDUsuarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDUsuarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDUsuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDUsuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDUsuarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDUsuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BDUsuarios] SET QUERY_STORE = ON
GO
ALTER DATABASE [BDUsuarios] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BDUsuarios]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 24/05/2023 2:22:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 24/05/2023 2:22:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Cedula] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[IdArea] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Area] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Area]
GO
/****** Object:  StoredProcedure [dbo].[AsignarUsuarioArea]    Script Date: 24/05/2023 2:22:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[AsignarUsuarioArea]
	@cedula nvarchar(50),
	@idArea int

	AS

	UPDATE dbo.Usuario
	SET IdArea =@idArea
	where Cedula = @cedula

GO
/****** Object:  StoredProcedure [dbo].[GuardarUsuario]    Script Date: 24/05/2023 2:22:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarUsuario]
@cedula AS NVARCHAR(50),
@nombre AS NVARCHAR(50),
@apellido AS NVARCHAR(50),
@direccion AS NVARCHAR(50)

AS
BEGIN
IF NOT EXISTS(SELECT Cedula FROM dbo.Usuario WHERE Cedula = @cedula)
BEGIN
INSERT INTO dbo.Usuario(Cedula, Nombre, Apellido, Direccion, FechaCreacion) 
values (@cedula, @nombre, @apellido, @direccion, GetDate());
END

END

GO
/****** Object:  StoredProcedure [dbo].[ObtenerAreas]    Script Date: 24/05/2023 2:22:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ObtenerAreas]

	AS

	SELECT Id, Nombre
	FROM dbo.Area
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarios]    Script Date: 24/05/2023 2:22:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[ObtenerUsuarios]

	AS

	SELECT TOP 10 Cedula, Nombre, Apellido, Direccion
	FROM dbo.Usuario
	ORDER BY FechaCreacion DESC;

GO
USE [master]
GO
ALTER DATABASE [BDUsuarios] SET  READ_WRITE 
GO
