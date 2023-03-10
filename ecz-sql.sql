USE [eczDB]
GO
/****** Object:  Table [dbo].[TBLReceteIlac]    Script Date: 02/24/2023 01:11:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLReceteIlac](
	[RIlacID] [int] IDENTITY(1,1) NOT NULL,
	[ReceteID] [int] NULL,
	[Adet] [int] NULL,
	[IlacID] [int] NULL,
 CONSTRAINT [PK_TBLReceteIlac] PRIMARY KEY CLUSTERED 
(
	[RIlacID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLRecete]    Script Date: 02/24/2023 01:11:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLRecete](
	[RctID] [int] IDENTITY(1,1) NOT NULL,
	[DoktorID] [int] NULL,
	[HastaID] [int] NULL,
	[Durum] [nvarchar](50) NULL,
	[ReceteAciklama] [nvarchar](max) NULL,
	[Tarih] [nvarchar](50) NULL,
 CONSTRAINT [PK_TBLRecete] PRIMARY KEY CLUSTERED 
(
	[RctID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLKullanici]    Script Date: 02/24/2023 01:11:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLKullanici](
	[KID] [int] IDENTITY(1,1) NOT NULL,
	[TC] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NULL,
	[KullaniciTip] [nvarchar](50) NULL,
	[AdSoyad] [nvarchar](50) NULL,
	[Cinsiyet] [nvarchar](50) NULL,
	[KullaniciKat] [nvarchar](50) NULL,
 CONSTRAINT [PK_TBLKullanici] PRIMARY KEY CLUSTERED 
(
	[KID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLIlaclar]    Script Date: 02/24/2023 01:11:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLIlaclar](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[IlacAdi] [nvarchar](150) NULL,
	[IlacKategori] [nvarchar](50) NULL,
 CONSTRAINT [PK_TBLIlaclar] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBLBolum]    Script Date: 02/24/2023 01:11:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLBolum](
	[BID] [int] IDENTITY(1,1) NOT NULL,
	[BAdi] [nvarchar](150) NULL,
 CONSTRAINT [PK_TBLBolum] PRIMARY KEY CLUSTERED 
(
	[BID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
