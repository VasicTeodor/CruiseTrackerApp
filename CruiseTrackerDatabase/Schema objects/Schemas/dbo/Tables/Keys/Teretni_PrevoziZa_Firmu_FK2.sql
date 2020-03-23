ALTER TABLE [dbo].[Teretni_PrevoziZa_Firmu]
	ADD CONSTRAINT [Teretni_PrevoziZa_Firmu_FK2]
	FOREIGN KEY (Firma_sifraFirme)
	REFERENCES [Firma] (sifraFirme)
