CREATE TRIGGER [BrodRemoveTrigger] ON [dbo].[Brod]
FOR DELETE
AS
BEGIN
	declare @brodId int;
	select @brodId = b.idBroda from inserted b;
	delete from Kapetan_Upravlja_Brodom where Kapetan_Upravlja_Brodom.Brod_idBroda = @brodId
END