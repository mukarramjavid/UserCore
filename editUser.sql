USE [UserWebApp]
GO
/****** Object:  StoredProcedure [dbo].[usp_EditUser]    Script Date: 9/21/2020 12:41:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[usp_EditUser]
@userID int

AS
	Begin
	
		  select * from tbl_Users u where u.user_id = @userID
		--select ad.city_name,ad.userID,u.user_name,u.user_email from tbl_Users u inner join  tbl_Address ad on u.user_id=2039
		--select * from tbl_Users u where u.user_id in (select ad.userID from tbl_Address ad where ad.userID=2039)

	END