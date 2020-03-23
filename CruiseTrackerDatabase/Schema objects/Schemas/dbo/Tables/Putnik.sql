CREATE TABLE [dbo].[Putnik]
(
	[jmbg] INT IDENTITY(1,1) NOT NULL, 
    [ime] VARCHAR(50) NOT NULL, 
    [prezime] VARCHAR(50) NOT NULL, 
    [brPasosa] INT NOT NULL, 
    [telefon] VARCHAR(50) NOT NULL
)
