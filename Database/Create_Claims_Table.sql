
CREATE TABLE [dbo].[Claims](
	[ClaimId] [uniqueidentifier] NOT NULL,
	[IdentityId] [uniqueidentifier] NOT NULL,
	[ClaimName] [varchar](128) NULL,
	[ClaimValue] [varchar](128) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Claims] ADD  CONSTRAINT [DF_Claims_ClaimId]  DEFAULT (newid()) FOR [ClaimId]
GO

ALTER TABLE [dbo].[Claims] ADD  CONSTRAINT [DF_Claims_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Claims]  WITH CHECK ADD  CONSTRAINT [FK_Claims_Identities] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[Identities] ([IdentityId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Claims] CHECK CONSTRAINT [FK_Claims_Identities]
GO


