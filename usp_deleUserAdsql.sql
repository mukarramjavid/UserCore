
CREATE PROCEDURE usp_delUserAddress
	@UserIdFK int
AS
BEGIN

	delete from tbl_Address where tbl_Address.address_id=@UserIdFK
	 --select SCOPE_IDENTITY() AS UserAddId
END
GO
