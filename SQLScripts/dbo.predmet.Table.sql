USE [getdb]
GO
/****** Object:  Table [dbo].[predmet]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[predmet](
	[PredmetId] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nchar](20) NULL,
 CONSTRAINT [PK_predmet] PRIMARY KEY CLUSTERED 
(
	[PredmetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[predmet]  WITH CHECK ADD  CONSTRAINT [FK_predmet_predmet] FOREIGN KEY([PredmetId])
REFERENCES [dbo].[predmet] ([PredmetId])
GO
ALTER TABLE [dbo].[predmet] CHECK CONSTRAINT [FK_predmet_predmet]
GO
