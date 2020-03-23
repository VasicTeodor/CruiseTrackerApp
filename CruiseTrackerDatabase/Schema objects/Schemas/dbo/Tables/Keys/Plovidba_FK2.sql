ALTER TABLE [dbo].[Plovidba]
	ADD CONSTRAINT [Plovidba_FK2]
	FOREIGN KEY (idKapetana)
	REFERENCES [Kapetan] (idKapetana)
