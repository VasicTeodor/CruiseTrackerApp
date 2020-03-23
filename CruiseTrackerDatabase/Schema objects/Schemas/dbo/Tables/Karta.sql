CREATE TABLE [dbo].[Karta]
(
	[brKarte] INT IDENTITY(1,1) NOT NULL, 
    [cena] DECIMAL NOT NULL, 
    [klasa] VARCHAR(50) NOT NULL, 
    [jmbg] INT NOT NULL, 
    [brAgencije] INT NULL, 
    [brPlovidbe] INT NOT NULL, 
    [datum] DATETIME NOT NULL, 
    [idBroda] INT NOT NULL
)
