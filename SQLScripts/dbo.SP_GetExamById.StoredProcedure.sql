USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetExamById]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_GetExamById]
	@IspitId int
as
BEGIN
	Select * From ispit Where IspitId=@IspitId
END
GO
