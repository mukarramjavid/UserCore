USE [UserWebApp]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_InsertUser]
		@userId = 4,
		@userName = N'ibad',
		@userEmail = N'ibad@yahoo.com',
		@userPwd = N'12',
		@userPhone = 12,
		@userAge = 312

SELECT	'Return Value' = @return_value

GO


select * from tbl_Users