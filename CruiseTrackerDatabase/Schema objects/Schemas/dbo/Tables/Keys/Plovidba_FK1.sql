ALTER TABLE [dbo].[Plovidba]
	ADD CONSTRAINT [Plovidba_FK1]
	FOREIGN KEY (brDestinacije)
	REFERENCES [Destinacija] (brDestinacije)
