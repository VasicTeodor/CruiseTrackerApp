ALTER TABLE [dbo].[Karta]
	ADD CONSTRAINT [Karta_FK4]
	FOREIGN KEY (idBroda)
	REFERENCES [Putnicki] (idBroda)
