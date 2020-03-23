ALTER TABLE [dbo].[Karta]
	ADD CONSTRAINT [Karta_FK1]
	FOREIGN KEY (jmbg)
	REFERENCES [Putnik] (jmbg)
