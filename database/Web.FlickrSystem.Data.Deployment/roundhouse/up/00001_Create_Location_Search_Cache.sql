USE [FlickrSystem]


CREATE TABLE [dbo].[LocationSearchCache](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SearchText] [varchar](50) NULL,
	[Result] [varchar](max) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_LocationSearchCache] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


