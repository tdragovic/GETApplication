USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_EditSubject]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_EditSubject]
(    @PredmetId int = 0,
	 @Naziv varchar(20)= ''
)
as
BEGIN

	Update predmet Set Naziv=@Naziv Where PredmetId=@PredmetId
	
END
GO
