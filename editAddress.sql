create proc usp_EditAddress
@userIDFK int
AS

Begin
	
	select * from tbl_Address ad where ad.userID = @userIDFK


End