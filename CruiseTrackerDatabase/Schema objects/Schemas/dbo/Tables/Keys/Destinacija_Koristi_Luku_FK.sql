ALTER TABLE [dbo].[Destinacija_Koristi_Luku]
	ADD CONSTRAINT [Destinacija_Koristi_Luku_FK]
	FOREIGN KEY (Luka_idLuke)
	REFERENCES [Luka] (idLuke)
