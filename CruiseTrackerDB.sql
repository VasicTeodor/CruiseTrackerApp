USE [master]
GO
/****** Object:  Database [CruiseTrackerDB]    Script Date: 23.3.2020. 22.10.52 ******/
CREATE DATABASE [CruiseTrackerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CruiseTrackerDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CruiseTrackerDB_Primary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CruiseTrackerDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CruiseTrackerDB_Primary.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CruiseTrackerDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CruiseTrackerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CruiseTrackerDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET ARITHABORT ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [CruiseTrackerDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [CruiseTrackerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CruiseTrackerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CruiseTrackerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CruiseTrackerDB] SET  MULTI_USER 
GO
ALTER DATABASE [CruiseTrackerDB] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [CruiseTrackerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CruiseTrackerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CruiseTrackerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CruiseTrackerDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CruiseTrackerDB', N'ON'
GO
ALTER DATABASE [CruiseTrackerDB] SET QUERY_STORE = OFF
GO
USE [CruiseTrackerDB]
GO
/****** Object:  Table [dbo].[Destinacija]    Script Date: 23.3.2020. 22.10.53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinacija](
	[brDestinacije] [int] IDENTITY(1,1) NOT NULL,
	[nazivDestinacije] [varchar](50) NOT NULL,
 CONSTRAINT [Destinacija_PK] PRIMARY KEY CLUSTERED 
(
	[brDestinacije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kapetan]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kapetan](
	[idKapetana] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[prezime] [varchar](50) NOT NULL,
 CONSTRAINT [Kapetan_PK] PRIMARY KEY CLUSTERED 
(
	[idKapetana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plovidba]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plovidba](
	[brPlovidbe] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NOT NULL,
	[opis] [varchar](50) NOT NULL,
	[polazak] [datetime] NOT NULL,
	[brPutnika] [int] NOT NULL,
	[brDestinacije] [int] NOT NULL,
	[idKapetana] [int] NOT NULL,
	[idLuke] [int] NOT NULL,
 CONSTRAINT [Plovidba_PK] PRIMARY KEY CLUSTERED 
(
	[brPlovidbe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCruisesCountForDestinationAndCaptain]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE FUNCTION dbo.GetCruisesCountForDestinationAndCaptain(@DESTNAME VARCHAR(50),@CAPNAME VARCHAR(50)) 
--RETURNS TABLE
--AS
--RETURN
--(
--    SELECT COUNT(*) AS Number 
--    FROM Plovidba p
--	INNER JOIN Kapetan k ON
--	k.idKapetana = p.idKapetana
--	INNER JOIN Destinacija d ON
--	d.brDestinacije = p.brDestinacije
--	WHERE d.nazivDestinacije = @DESTNAME and k.ime = @CAPNAME
--);
--GO

--CREATE TRIGGER [BrodTrigger] ON [dbo].[Brod]
--FOR INSERT
--AS
--BEGIN
--	declare @brodId int;
--	select @brodId = b.idBroda from inserted b;
--	insert into Kapetan_Upravlja_Brodom values (1, @brodId)
--END

--CREATE TRIGGER [TeretniBrodRemoveTrigger] ON [dbo].[Teretni]
--FOR DELETE
--AS
--BEGIN
--	declare @brodId int;
--	select @brodId = b.idBroda from inserted b;
--	delete from Kapetan_Upravlja_Brodom where Kapetan_Upravlja_Brodom.Brod_idBroda = @brodId
--END

CREATE FUNCTION [dbo].[GetCruisesCountForDestinationAndCaptain](@DESTNAME VARCHAR(50),@CAPNAME VARCHAR(50)) 
RETURNS TABLE
AS
RETURN
(
	SELECT COUNT(*) AS Number 
	FROM Plovidba p
	INNER JOIN Kapetan k ON
	k.idKapetana = p.idKapetana
	INNER JOIN Destinacija d ON
	d.brDestinacije = p.brDestinacije
	WHERE d.nazivDestinacije = @DESTNAME and k.ime = @CAPNAME
);
GO
/****** Object:  Table [dbo].[Agencija]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agencija](
	[brAgencije] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NOT NULL,
	[adresa] [varchar](50) NOT NULL,
	[telefon] [varchar](50) NULL,
 CONSTRAINT [Agencija_PK] PRIMARY KEY CLUSTERED 
(
	[brAgencije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brod]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brod](
	[idBroda] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NOT NULL,
 CONSTRAINT [Brod_PK] PRIMARY KEY CLUSTERED 
(
	[idBroda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destinacija_Koristi_Luku]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinacija_Koristi_Luku](
	[Destinacija_brDestinacije] [int] NOT NULL,
	[Luka_idLuke] [int] NOT NULL,
 CONSTRAINT [Destinacija_Koristi_Luku_PK] PRIMARY KEY CLUSTERED 
(
	[Destinacija_brDestinacije] ASC,
	[Luka_idLuke] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firma]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[sifraFirme] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](50) NOT NULL,
	[oblastPoslovanja] [varchar](50) NOT NULL,
 CONSTRAINT [Firma_PK] PRIMARY KEY CLUSTERED 
(
	[sifraFirme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kapetan_Upravlja_Brodom]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kapetan_Upravlja_Brodom](
	[Kapetan_idKapetana] [int] NOT NULL,
	[Brod_idBroda] [int] NOT NULL,
 CONSTRAINT [Kapetan_Upravlja_Brodom_PK] PRIMARY KEY CLUSTERED 
(
	[Kapetan_idKapetana] ASC,
	[Brod_idBroda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Karta]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Karta](
	[brKarte] [int] IDENTITY(1,1) NOT NULL,
	[cena] [decimal](18, 0) NOT NULL,
	[klasa] [varchar](50) NOT NULL,
	[jmbg] [int] NOT NULL,
	[brAgencije] [int] NULL,
	[brPlovidbe] [int] NOT NULL,
	[datum] [datetime] NOT NULL,
	[idBroda] [int] NOT NULL,
 CONSTRAINT [Karta_PK] PRIMARY KEY CLUSTERED 
(
	[brKarte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[Id] [int] NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [Korisnik_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luka]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luka](
	[idLuke] [int] IDENTITY(1,1) NOT NULL,
	[brDokova] [int] NOT NULL,
	[naziv] [varchar](50) NOT NULL,
	[mesto] [varchar](50) NOT NULL,
	[drzava] [varchar](50) NOT NULL,
 CONSTRAINT [Luka_PK] PRIMARY KEY CLUSTERED 
(
	[idLuke] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Putnicki]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Putnicki](
	[idBroda] [int] NOT NULL,
	[brPutnika] [int] NOT NULL,
	[brKabina] [int] NOT NULL,
 CONSTRAINT [Putnicki_PK] PRIMARY KEY CLUSTERED 
(
	[idBroda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Putnik]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Putnik](
	[jmbg] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[prezime] [varchar](50) NOT NULL,
	[brPasosa] [int] NOT NULL,
	[telefon] [varchar](50) NOT NULL,
 CONSTRAINT [Putnik_PK] PRIMARY KEY CLUSTERED 
(
	[jmbg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teretni]    Script Date: 23.3.2020. 22.10.54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teretni](
	[idBroda] [int] NOT NULL,
	[nosivost] [float] NOT NULL,
	[brKontejnera] [int] NOT NULL,
 CONSTRAINT [Teretni_PK] PRIMARY KEY CLUSTERED 
(
	[idBroda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teretni_PrevoziZa_Firmu]    Script Date: 23.3.2020. 22.10.55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teretni_PrevoziZa_Firmu](
	[Teretni_idBroda] [int] NOT NULL,
	[Firma_sifraFirme] [int] NOT NULL,
 CONSTRAINT [Teretni_PrevoziZa_Firmu_PK] PRIMARY KEY CLUSTERED 
(
	[Teretni_idBroda] ASC,
	[Firma_sifraFirme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Destinacija_Koristi_Luku]  WITH CHECK ADD  CONSTRAINT [Destinacija_Koristi_Luku_FK] FOREIGN KEY([Luka_idLuke])
REFERENCES [dbo].[Luka] ([idLuke])
GO
ALTER TABLE [dbo].[Destinacija_Koristi_Luku] CHECK CONSTRAINT [Destinacija_Koristi_Luku_FK]
GO
ALTER TABLE [dbo].[Kapetan_Upravlja_Brodom]  WITH CHECK ADD  CONSTRAINT [Kapetan_Upravlja_Brodom_FK1] FOREIGN KEY([Kapetan_idKapetana])
REFERENCES [dbo].[Kapetan] ([idKapetana])
GO
ALTER TABLE [dbo].[Kapetan_Upravlja_Brodom] CHECK CONSTRAINT [Kapetan_Upravlja_Brodom_FK1]
GO
ALTER TABLE [dbo].[Kapetan_Upravlja_Brodom]  WITH CHECK ADD  CONSTRAINT [Kapetan_Upravlja_Brodom_FK2] FOREIGN KEY([Brod_idBroda])
REFERENCES [dbo].[Brod] ([idBroda])
GO
ALTER TABLE [dbo].[Kapetan_Upravlja_Brodom] CHECK CONSTRAINT [Kapetan_Upravlja_Brodom_FK2]
GO
ALTER TABLE [dbo].[Karta]  WITH CHECK ADD  CONSTRAINT [Karta_FK1] FOREIGN KEY([jmbg])
REFERENCES [dbo].[Putnik] ([jmbg])
GO
ALTER TABLE [dbo].[Karta] CHECK CONSTRAINT [Karta_FK1]
GO
ALTER TABLE [dbo].[Karta]  WITH CHECK ADD  CONSTRAINT [Karta_FK2] FOREIGN KEY([brAgencije])
REFERENCES [dbo].[Agencija] ([brAgencije])
GO
ALTER TABLE [dbo].[Karta] CHECK CONSTRAINT [Karta_FK2]
GO
ALTER TABLE [dbo].[Karta]  WITH CHECK ADD  CONSTRAINT [Karta_FK3] FOREIGN KEY([brPlovidbe])
REFERENCES [dbo].[Plovidba] ([brPlovidbe])
GO
ALTER TABLE [dbo].[Karta] CHECK CONSTRAINT [Karta_FK3]
GO
ALTER TABLE [dbo].[Karta]  WITH CHECK ADD  CONSTRAINT [Karta_FK4] FOREIGN KEY([idBroda])
REFERENCES [dbo].[Putnicki] ([idBroda])
GO
ALTER TABLE [dbo].[Karta] CHECK CONSTRAINT [Karta_FK4]
GO
ALTER TABLE [dbo].[Plovidba]  WITH CHECK ADD  CONSTRAINT [Plovidba_FK1] FOREIGN KEY([brDestinacije])
REFERENCES [dbo].[Destinacija] ([brDestinacije])
GO
ALTER TABLE [dbo].[Plovidba] CHECK CONSTRAINT [Plovidba_FK1]
GO
ALTER TABLE [dbo].[Plovidba]  WITH CHECK ADD  CONSTRAINT [Plovidba_FK2] FOREIGN KEY([idKapetana])
REFERENCES [dbo].[Kapetan] ([idKapetana])
GO
ALTER TABLE [dbo].[Plovidba] CHECK CONSTRAINT [Plovidba_FK2]
GO
ALTER TABLE [dbo].[Plovidba]  WITH CHECK ADD  CONSTRAINT [Plovidba_FK3] FOREIGN KEY([idLuke])
REFERENCES [dbo].[Luka] ([idLuke])
GO
ALTER TABLE [dbo].[Plovidba] CHECK CONSTRAINT [Plovidba_FK3]
GO
ALTER TABLE [dbo].[Putnicki]  WITH NOCHECK ADD  CONSTRAINT [Putnicki_Brod_FK] FOREIGN KEY([idBroda])
REFERENCES [dbo].[Brod] ([idBroda])
GO
ALTER TABLE [dbo].[Putnicki] CHECK CONSTRAINT [Putnicki_Brod_FK]
GO
ALTER TABLE [dbo].[Teretni]  WITH NOCHECK ADD  CONSTRAINT [Teretni_FK] FOREIGN KEY([idBroda])
REFERENCES [dbo].[Brod] ([idBroda])
GO
ALTER TABLE [dbo].[Teretni] CHECK CONSTRAINT [Teretni_FK]
GO
ALTER TABLE [dbo].[Teretni_PrevoziZa_Firmu]  WITH NOCHECK ADD  CONSTRAINT [Teretni_PrevoziZa_Firmu_FK1] FOREIGN KEY([Teretni_idBroda])
REFERENCES [dbo].[Teretni] ([idBroda])
GO
ALTER TABLE [dbo].[Teretni_PrevoziZa_Firmu] CHECK CONSTRAINT [Teretni_PrevoziZa_Firmu_FK1]
GO
ALTER TABLE [dbo].[Teretni_PrevoziZa_Firmu]  WITH CHECK ADD  CONSTRAINT [Teretni_PrevoziZa_Firmu_FK2] FOREIGN KEY([Firma_sifraFirme])
REFERENCES [dbo].[Firma] ([sifraFirme])
GO
ALTER TABLE [dbo].[Teretni_PrevoziZa_Firmu] CHECK CONSTRAINT [Teretni_PrevoziZa_Firmu_FK2]
GO
/****** Object:  StoredProcedure [dbo].[BrojPlovidbiZaIstuDestinacijuIKapetana]    Script Date: 23.3.2020. 22.10.55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BrojPlovidbiZaIstuDestinacijuIKapetana]
@IDDEST int,
@KAPIME varchar(50)
  AS
BEGIN
    SET NOCOUNT ON;
     SELECT COUNT(*) 
         FROM Plovidba p
		 INNER JOIN Kapetan k ON
		 k.idKapetana = p.idKapetana
		 WHERE p.brDestinacije = @IDDEST and k.ime = @KAPIME
END
GO
USE [master]
GO
ALTER DATABASE [CruiseTrackerDB] SET  READ_WRITE 
GO
