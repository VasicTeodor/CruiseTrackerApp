ALTER TABLE [dbo].[Teretni]
	ADD CONSTRAINT [Teretni_FK]
	FOREIGN KEY (idBroda)
	REFERENCES [Brod] (idBroda)
