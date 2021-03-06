USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllExamsSorted]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetAllExamsSorted]
AS
BEGIN

	SELECT ispit.*, predmet.Naziv, student.Ime, Prezime
	FROM ispit
	INNER JOIN predmet 
	ON ispit.predmetId = predmet.predmetId
	Inner join student
	on ispit.BrojIndeksa = student.BrojIndeksa
	order by DatumKreiranja desc

END

GO
