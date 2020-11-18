create or alter proc usp_DelMasterUserAddress

	@UserIdFK int
AS
BEGIN

	delete from tbl_InsertMaster where tbl_InsertMaster.userId =@UserIdFK

END
