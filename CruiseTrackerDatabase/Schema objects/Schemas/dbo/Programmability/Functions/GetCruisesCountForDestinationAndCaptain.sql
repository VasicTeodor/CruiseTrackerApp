CREATE FUNCTION dbo.GetCruisesCountForDestinationAndCaptain(@DESTNAME VARCHAR(50),@CAPNAME VARCHAR(50)) 
RETURNS TABLE
AS
RETURN
(
	SELECT COUNT(*) AS Number 
	FROM Plovidba p
	INNER JOIN Kapetan k ON
	k.idKapetana = p.idKapetana
	INNER JOIN Destinacija d ON
	d.brDestinacije = p.brDestinacije
	WHERE d.nazivDestinacije = @DESTNAME and k.ime = @CAPNAME
);
GO
