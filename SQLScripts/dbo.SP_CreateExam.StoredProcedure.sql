USE [getdb]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateExam]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_CreateExam]
(	
	@BrojIndeksa varchar(10) = '',
	@PredmetId int = 0,
	@Ocena int = 0,
	@DatumPolaganja datetime = NULL,
	@DatumKreiranja datetime = NULL,
	@DatumPoslednjeIzmene datetime = NULL
)
as
BEGIN
	Insert Into ispit (BrojIndeksa, PredmetId, Ocena, DatumPolaganja, DatumKreiranja, DatumPoslednjeIzmene) 
	Values(@BrojIndeksa, @PredmetId, @Ocena,  @DatumPolaganja, GETDATE() , GETDATE())
END
GO
