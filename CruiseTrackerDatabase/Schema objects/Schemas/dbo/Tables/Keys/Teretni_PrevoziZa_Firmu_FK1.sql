ALTER TABLE [dbo].[Teretni_PrevoziZa_Firmu]
	ADD CONSTRAINT [Teretni_PrevoziZa_Firmu_FK1]
	FOREIGN KEY (Teretni_idBroda)
	REFERENCES [Teretni] (idBroda)
