USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteSubject]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_DeleteSubject]
	@PredmetId int	 
as
BEGIN
	Delete From predmet Where PredmetId=@PredmetId
END
GO
