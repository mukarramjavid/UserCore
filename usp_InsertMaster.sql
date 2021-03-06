USE [UserWebApp]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertMaster]    Script Date: 11/5/2020 11:52:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROC [dbo].[usp_InsertMaster]

--EXEC usp_InsertMaster 1, 'mukarram','mukarram@yahoo.com','123','03238883647','1','1,2,3'
@_userId int,
@_userName nvarchar(MAX),
@_userEmail nvarchar(MAX),
@_userPwd nvarchar(MAX),
@_userPhone nvarchar(MAX),
@_userCountryId int,
@_skillIds nvarchar(MAX),
@_userProvinceId int

AS

BEGIN
		if exists(select 1 FROM tbl_InsertMaster where userEmail=@_userEmail) 
				BEGIN
					update tbl_InsertMaster SET userEmail=@_userEmail,
												userPwd=@_userPwd,
												userName=@_userName,
												userPhone=@_userPhone,
												countryId=@_userCountryId,
												skillIds=@_skillIds,
												provinceId=@_userProvinceId

									where 
										userId=@_userId
										select @_userId AS Id

				END
		else
				Begin
						Insert into tbl_InsertMaster
												  (userEmail,userName,userPwd,userPhone,countryId,skillIds,provinceId)
										 values		
												  (@_userEmail, @_userName,@_userPwd,@_userPhone,@_userCountryId,@_skillIds,@_userProvinceId)

				END
END