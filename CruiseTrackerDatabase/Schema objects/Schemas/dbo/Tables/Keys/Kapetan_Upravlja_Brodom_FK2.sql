ALTER TABLE [dbo].[Kapetan_Upravlja_Brodom]
	ADD CONSTRAINT [Kapetan_Upravlja_Brodom_FK2]
	FOREIGN KEY (Brod_idBroda)
	REFERENCES [Brod] (idBroda)
