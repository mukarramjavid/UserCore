USE [UserWebApp]
GO
/****** Object:  StoredProcedure [dbo].[usp_EditMasterUser]    Script Date: 11/4/2020 12:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[usp_EditMasterUser]
--EXEC usp_EditMasterUser '2019'
@userIDFK int
AS

BEgin 
			select * from tbl_InsertMaster u where u.userId= @userIDFK
end