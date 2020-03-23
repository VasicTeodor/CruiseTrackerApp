CREATE TABLE [dbo].[Agencija]
(
	[brAgencije] INT IDENTITY(1,1) NOT NULL, 
    [naziv] VARCHAR(50) NOT NULL, 
    [adresa] VARCHAR(50) NOT NULL, 
    [telefon] VARCHAR(50) NULL
)
