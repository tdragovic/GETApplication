USE [getdb]
GO
/****** Object:  Table [dbo].[ispit]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ispit](
	[IspitId] [int] IDENTITY(1,1) NOT NULL,
	[BrojIndeksa] [nchar](10) NULL,
	[PredmetId] [int] NULL,
	[Ocena] [int] NULL,
	[DatumPolaganja] [datetime] NULL,
	[DatumKreiranja] [datetime] NULL,
	[DatumPoslednjeIzmene] [datetime] NULL,
 CONSTRAINT [PK_ispit_1] PRIMARY KEY CLUSTERED 
(
	[IspitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ispit]  WITH CHECK ADD  CONSTRAINT [FK_ispit_brojIndeksa] FOREIGN KEY([BrojIndeksa])
REFERENCES [dbo].[student] ([BrojIndeksa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ispit] CHECK CONSTRAINT [FK_ispit_brojIndeksa]
GO
ALTER TABLE [dbo].[ispit]  WITH CHECK ADD  CONSTRAINT [FK_ispit_predmetId] FOREIGN KEY([PredmetId])
REFERENCES [dbo].[predmet] ([PredmetId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ispit] CHECK CONSTRAINT [FK_ispit_predmetId]
GO
