ALTER TABLE [dbo].[Kapetan_Upravlja_Brodom]
	ADD CONSTRAINT [Kapetan_Upravlja_Brodom_FK1]
	FOREIGN KEY (Kapetan_idKapetana)
	REFERENCES [Kapetan] (idKapetana)
