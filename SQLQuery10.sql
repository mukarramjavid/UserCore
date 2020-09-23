USE [UserWebApp]
GO

/****** Object:  StoredProcedure [dbo].[usp_InsertUser]    Script Date: 9/17/2020 7:04:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create OR alter proc [dbo].[usp_InsertUser]
-- EXEC usp_InsertUser '1016','jdjdjd','asdfds@yahoo.com','123', 0303425541,27
@userId int = 0,
@userName nvarchar(MAX),
@userEmail nvarchar(MAX),
@userPwd nvarchar(MAX),
@userPhone int,
@userAge int

	AS
Begin 
		if exists(select 1 FROM tbl_Users where user_email=@userEmail) 
		BEGIN
			update tbl_Users set user_email=@userEmail,
								 user_pwd=@userPwd,
								 user_name=@userName,
								 user_phone=@userPhone,
								 user_age=@userAge
							where 
								user_id=@userId
								select @userId

		END
		else
		BEGIN
			Insert into tbl_Users 
								  (user_email,user_name,user_pwd,user_phone,user_age)
						 values		
								  (@userEmail, @userName,@userPwd,@userPhone,@userAge)



			

	   select SCOPE_IDENTITY()
	END
	--select SCOPE_IDENTITY()
End
GO

--exec usp_InsertUser


