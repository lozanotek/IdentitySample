

CREATE TABLE [dbo].[Sessions](
	[SessionId] [uniqueidentifier] NOT NULL,
	[IdentityId] [uniqueidentifier] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_IdentitySession] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [DF_IdentitySession_SessionId]  DEFAULT (newid()) FOR [SessionId]
GO

ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [DF_IdentitySession_StartDate]  DEFAULT (getdate()) FOR [StartDate]
GO

ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Identities] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[Identities] ([IdentityId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Identities]
GO


