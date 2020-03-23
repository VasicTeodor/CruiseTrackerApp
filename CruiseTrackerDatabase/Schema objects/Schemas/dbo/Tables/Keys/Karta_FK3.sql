ALTER TABLE [dbo].[Karta]
	ADD CONSTRAINT [Karta_FK3]
	FOREIGN KEY (brPlovidbe)
	REFERENCES [Plovidba] (brPlovidbe)
