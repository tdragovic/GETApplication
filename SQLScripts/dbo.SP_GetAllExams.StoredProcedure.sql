USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllExams]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_GetAllExams]
as
BEGIN
	Select * From ispit
END
GO
