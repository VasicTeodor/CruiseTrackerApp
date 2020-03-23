CREATE TABLE [dbo].[Plovidba]
(
	[brPlovidbe] INT IDENTITY(1,1) NOT NULL, 
    [naziv] VARCHAR(50) NOT NULL, 
    [opis] VARCHAR(50) NOT NULL, 
    [polazak] DATETIME NOT NULL, 
    [brPutnika] INT NOT NULL, 
    [brDestinacije] INT NOT NULL, 
    [idKapetana] INT NOT NULL, 
    [idLuke] INT NOT NULL
)
