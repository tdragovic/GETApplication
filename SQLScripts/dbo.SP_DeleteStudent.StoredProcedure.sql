USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteStudent]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_DeleteStudent]
	@StudentId int
as
BEGIN
	Delete From student Where StudentId=@StudentId
END
GO
