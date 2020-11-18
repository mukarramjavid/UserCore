USE [UserWebApp]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMasterUsersList]    Script Date: 11/5/2020 11:57:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_GetMasterUsersList]

AS

BEGIN
	--SELECT * FROM tbl_InsertMaster
	SELECT im.userId,im.userEmail,im.userName,im.userPhone,im.userPwd,c.countryName,im.skillIds,p.provinceName FROM tbl_InsertMaster im 
	INNER JOIN tbl_Country c ON im.countryId=c.countryId
	INNER JOIN tbl_Province p ON im.provinceId=p.provinceId
	
	 
	
END