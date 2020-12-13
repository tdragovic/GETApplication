USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateStudent]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_CreateStudent]
(	
	@BrojIndeksa varchar(10) = '',
	@Ime varchar(10) = '',
	@Prezime varchar(10) = '',
	@Grad varchar(10) = ''
)
as
BEGIN
	Insert Into student(BrojIndeksa, Ime, Prezime, Grad)
	Values(@BrojIndeksa, @Ime, @Prezime, @Grad)
END
GO
