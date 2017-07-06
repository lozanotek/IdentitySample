

CREATE TABLE [dbo].[Credentials](
	[CredentialId] [uniqueidentifier] NOT NULL,
	[IdentityId] [uniqueidentifier] NOT NULL,
	[Type] [varchar](50) NULL,
	[Subject] [varchar](128) NULL,
	[Value] [varchar](128) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Credentials] PRIMARY KEY CLUSTERED 
(
	[CredentialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Credentials] ADD  CONSTRAINT [DF_Credentials_CredentialId]  DEFAULT (newid()) FOR [CredentialId]
GO

ALTER TABLE [dbo].[Credentials] ADD  CONSTRAINT [DF_Credential_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Credentials]  WITH CHECK ADD  CONSTRAINT [FK_Credentials_Identities] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[Identities] ([IdentityId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Credentials] CHECK CONSTRAINT [FK_Credentials_Identities]
GO


