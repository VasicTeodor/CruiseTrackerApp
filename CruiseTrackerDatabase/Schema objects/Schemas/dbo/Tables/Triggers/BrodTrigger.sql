CREATE TRIGGER [BrodTrigger] ON [dbo].[Brod]
FOR INSERT
AS
BEGIN
	declare @brodId int;
	select @brodId = b.idBroda from inserted b;
	insert into Kapetan_Upravlja_Brodom values (1, @brodId)
END