USE [getdb]
GO
/****** Object:  Table [dbo].[student]    Script Date: 12/14/2020 12:34:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[BrojIndeksa] [nchar](10) NOT NULL,
	[Ime] [nchar](10) NULL,
	[Prezime] [nchar](10) NULL,
	[Grad] [nchar](10) NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[BrojIndeksa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
