CREATE TRIGGER [PutnickiBrodRemoveTrigger] ON [dbo].[Teretni]
FOR DELETE
AS
BEGIN
	declare @brodId int;
	select @brodId = b.idBroda from inserted b;
	delete from Kapetan_Upravlja_Brodom where Kapetan_Upravlja_Brodom.Brod_idBroda = @brodId
END