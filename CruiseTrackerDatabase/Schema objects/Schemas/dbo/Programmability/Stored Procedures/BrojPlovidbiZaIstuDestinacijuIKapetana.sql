CREATE PROC BrojPlovidbiZaIstuDestinacijuIKapetana
@IDDEST int,
@KAPIME varchar(50)
  AS
BEGIN
	SET NOCOUNT ON;
	 SELECT COUNT(*) 
		 FROM Plovidba p
		 INNER JOIN Kapetan k ON
		 k.idKapetana = p.idKapetana
		 WHERE p.brDestinacije = @IDDEST and k.ime = @KAPIME
END