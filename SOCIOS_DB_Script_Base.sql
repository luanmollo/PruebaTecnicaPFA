CREATE DATABASE [SOCIOS_DB]
GO
USE [SOCIOS_DB]
GO

CREATE TABLE [dbo].[tbl_Pagos_Socio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [float] NOT NULL,
	[MontoFinal] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdSocio] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Pagos_Socio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbl_Socio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[TipoDocId] [int] NOT NULL,
	[Documento] [nvarchar](50) NOT NULL,
	[TipoSocioId] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[ContactoId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Socio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbl_Socio_Contacto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Telefonos] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Socio_Contacto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbl_Tipo_Documento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Tipo_Documento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tbl_Tipo_Socio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Tipo_Socio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Tipo_Documento] ON 

INSERT [dbo].[tbl_Tipo_Documento] ([Id], [Nombre]) VALUES (1, N'Dni')
INSERT [dbo].[tbl_Tipo_Documento] ([Id], [Nombre]) VALUES (2, N'Libreta de enrolamiento')
SET IDENTITY_INSERT [dbo].[tbl_Tipo_Documento] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Tipo_Socio] ON 

INSERT [dbo].[tbl_Tipo_Socio] ([Id], [Nombre]) VALUES (1, N'Vitalicio')
INSERT [dbo].[tbl_Tipo_Socio] ([Id], [Nombre]) VALUES (2, N'Regular')
INSERT [dbo].[tbl_Tipo_Socio] ([Id], [Nombre]) VALUES (3, N'No Socio')
SET IDENTITY_INSERT [dbo].[tbl_Tipo_Socio] OFF
GO
USE [master]
GO
ALTER DATABASE [SOCIOS_DB] SET  READ_WRITE 
GO