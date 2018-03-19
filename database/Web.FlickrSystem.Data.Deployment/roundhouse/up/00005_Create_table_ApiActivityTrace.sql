CREATE TABLE [dbo].[ApiActivityTrace](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[TimeElapsedMS] [int] NOT NULL,
	[StatusCode] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_ApiActivityTrace] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ApiActivityTrace]  WITH CHECK ADD  CONSTRAINT [FK_ApiActivityTrace_ApiActionType1] FOREIGN KEY([ActionId])
REFERENCES [enum].[ApiActionType] ([Id])
GO

ALTER TABLE [dbo].[ApiActivityTrace] CHECK CONSTRAINT [FK_ApiActivityTrace_ApiActionType1]
GO

ALTER TABLE [dbo].[ApiActivityTrace]  WITH CHECK ADD  CONSTRAINT [FK_ApiActivityTrace_ApiProviderType1] FOREIGN KEY([ProviderId])
REFERENCES [enum].[ApiProviderType] ([Id])
GO

ALTER TABLE [dbo].[ApiActivityTrace] CHECK CONSTRAINT [FK_ApiActivityTrace_ApiProviderType1]
GO


