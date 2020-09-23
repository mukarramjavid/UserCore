create proc usp_DeleteUser
@UserID int

as

	begin 
		
		delete from tbl_Users where tbl_Users.user_id=@UserID

	end


