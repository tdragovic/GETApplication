USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateSubject]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_CreateSubject]
	@Naziv varchar(20) = ''
as
BEGIN
	Insert into predmet(Naziv) 
	Values(@Naziv)
END
GO
