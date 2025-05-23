USE [master]
GO
/****** Object:  Database [ApiPeliculasNRT8]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE DATABASE [ApiPeliculasNRT8]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApiPeliculasNRT8', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ApiPeliculasNRT8.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApiPeliculasNRT8_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ApiPeliculasNRT8_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ApiPeliculasNRT8] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApiPeliculasNRT8].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApiPeliculasNRT8] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET RECOVERY FULL 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET  MULTI_USER 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApiPeliculasNRT8] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApiPeliculasNRT8] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ApiPeliculasNRT8', N'ON'
GO
ALTER DATABASE [ApiPeliculasNRT8] SET QUERY_STORE = ON
GO
ALTER DATABASE [ApiPeliculasNRT8] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ApiPeliculasNRT8]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/05/2025 12:30:47 a. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pelicula](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Duracion] [int] NOT NULL,
	[RutaImagen] [nvarchar](max) NULL,
	[Clasificacion] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[categoriaId] [int] NOT NULL,
	[RutaLocalIMagen] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pelicula] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/05/2025 12:30:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](max) NULL,
	[Nombre] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250425165230_MicgracionInicial', N'9.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250428181015_soportedesubidaimagenespeliculas', N'9.0.3')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7c25110c-3f98-49b1-b7b7-e0c1656aba5d', N'admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'eeef982f-147f-418d-ae39-6d957001e729', N'Registrado', N'REGISTRADO', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9bd306e6-cd11-4267-b2e3-276974537288', N'7c25110c-3f98-49b1-b7b7-e0c1656aba5d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ecd4d16f-2ce9-4f69-b88e-56187be9b11e', N'7c25110c-3f98-49b1-b7b7-e0c1656aba5d')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Nombre], [Apellido], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9bd306e6-cd11-4267-b2e3-276974537288', N'admin', NULL, N'admin', N'ADMIN', N'admin', N'ADMIN', 0, N'AQAAAAIAAYagAAAAED6ZYD0ULIw4IUkZMsh4NP69JpAFNt5zpruihv2y4a1GxgKaGmVa1NW3r/AKE9h0qw==', N'Q2AE6CBYWERLLOBTPO4R7BL2RXM3CZ44', N'4e0c8dd3-b2d7-4b68-bcef-25be39e2a4da', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Nombre], [Apellido], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ecd4d16f-2ce9-4f69-b88e-56187be9b11e', N'usuario', NULL, N'usuario', N'USUARIO', N'usuario', N'USUARIO', 0, N'AQAAAAIAAYagAAAAEMkbM6WFlCMS9OW3b0WSsp6Ix4EXTmHle5roiJnuWN0xqZOhxuCxulbeK33jcI20OA==', N'B35R4T4LA7DSO7LDUH3KQE73WQJ2HWUT', N'8981bc64-ccf0-4620-8429-7e9b6c714f32', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (1, N'Accion', CAST(N'2025-04-25T12:02:19.8950306' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (2, N'Aventura', CAST(N'2025-04-25T12:02:53.6219526' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (3, N'Animación', CAST(N'2025-04-25T12:03:29.9588771' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (4, N'Biografía', CAST(N'2025-04-25T12:03:38.7044416' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (5, N'Comedia', CAST(N'2025-04-25T12:03:46.4104108' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (6, N'Crimen', CAST(N'2025-04-25T12:03:56.0254105' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (7, N'Documental', CAST(N'2025-04-25T12:04:03.5644926' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (8, N'Drama', CAST(N'2025-04-25T12:04:12.8143241' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (9, N'Familia', CAST(N'2025-04-25T12:04:20.7246308' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (10, N'Fantasía', CAST(N'2025-04-25T12:04:31.1633583' AS DateTime2))
INSERT [dbo].[Categorias] ([Id], [Nombre], [FechaCreacion]) VALUES (11, N'Porno', CAST(N'2025-04-25T12:04:46.3975086' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Pelicula] ON 

INSERT [dbo].[Pelicula] ([Id], [Nombre], [Descripcion], [Duracion], [RutaImagen], [Clasificacion], [FechaCreacion], [categoriaId], [RutaLocalIMagen]) VALUES (1, N'John Wick (2014)', N'Un exasesino a sueldo regresa a la acción en busca de venganza. Coreografías de pelea brutales y estilizadas.', 90, N'string', 9, CAST(N'2025-04-25T12:07:14.1794791' AS DateTime2), 1, NULL)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Descripcion], [Duracion], [RutaImagen], [Clasificacion], [FechaCreacion], [categoriaId], [RutaLocalIMagen]) VALUES (2, N'Mad Max: Fury Road (2015)', N'Una persecución salvaje en un mundo post-apocalíptico. Visualmente espectacular y con acción sin descanso.', 120, N'string', 9, CAST(N'2025-04-25T12:07:41.5713311' AS DateTime2), 1, NULL)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Descripcion], [Duracion], [RutaImagen], [Clasificacion], [FechaCreacion], [categoriaId], [RutaLocalIMagen]) VALUES (3, N'Gladiator (2000)', N'Un general romano cae en desgracia y se convierte en gladiador para vengar la muerte de su familia.', 120, N'string', 9, CAST(N'2025-04-25T12:08:07.6258099' AS DateTime2), 1, NULL)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Descripcion], [Duracion], [RutaImagen], [Clasificacion], [FechaCreacion], [categoriaId], [RutaLocalIMagen]) VALUES (4, N'The Dark Knight (2008)', N'Batman enfrenta al Joker en una historia intensa y llena de escenas de acción memorables.', 160, N'string', 9, CAST(N'2025-04-25T12:09:43.9087735' AS DateTime2), 1, NULL)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Descripcion], [Duracion], [RutaImagen], [Clasificacion], [FechaCreacion], [categoriaId], [RutaLocalIMagen]) VALUES (5, N'batman', N'prueba de batman', 150, N'https://localhost:7180/ImagenesPeliculas/56e4f5dde-e0cf-40c5-a04f-37a1b09f6770.jpeg', 2, CAST(N'2025-04-28T15:53:49.0150974' AS DateTime2), 2, N'wwwroot\ImagenesPeliculas\56e4f5dde-e0cf-40c5-a04f-37a1b09f6770.jpeg')
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Descripcion], [Duracion], [RutaImagen], [Clasificacion], [FechaCreacion], [categoriaId], [RutaLocalIMagen]) VALUES (6, N'The Dark Knight (2008) 2', N'Batman enfrenta al Joker en una historia intensa y llena de escenas de acción memorables.', 160, N'https://placehold.co/600x400', 2, CAST(N'2025-04-28T15:33:20.8400357' AS DateTime2), 1, NULL)
INSERT [dbo].[Pelicula] ([Id], [Nombre], [Descripcion], [Duracion], [RutaImagen], [Clasificacion], [FechaCreacion], [categoriaId], [RutaLocalIMagen]) VALUES (7, N'The Dark Knight (2008) 3', N'Batman enfrenta al Joker en una historia intensa y llena de escenas de acción memorables.', 160, N'https://placehold.co/600x400', 2, CAST(N'2025-04-28T15:33:59.1149093' AS DateTime2), 1, NULL)
SET IDENTITY_INSERT [dbo].[Pelicula] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [NombreUsuario], [Nombre], [Role], [Password]) VALUES (1, N'admin', N'admin', N'admin', N'81dc9bdb52d04dc20036dbd8313ed055')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pelicula_categoriaId]    Script Date: 6/05/2025 12:30:47 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Pelicula_categoriaId] ON [dbo].[Pelicula]
(
	[categoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Pelicula]  WITH CHECK ADD  CONSTRAINT [FK_Pelicula_Categorias_categoriaId] FOREIGN KEY([categoriaId])
REFERENCES [dbo].[Categorias] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pelicula] CHECK CONSTRAINT [FK_Pelicula_Categorias_categoriaId]
GO
USE [master]
GO
ALTER DATABASE [ApiPeliculasNRT8] SET  READ_WRITE 
GO
