ALTER TABLE [dbo].[Karta]
	ADD CONSTRAINT [Karta_FK2]
	FOREIGN KEY (brAgencije)
	REFERENCES [Agencija] (brAgencije)
