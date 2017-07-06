

CREATE TABLE [dbo].[Identities](
	[IdentityId] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](128) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Identity] PRIMARY KEY CLUSTERED 
(
	[IdentityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Identities] ADD  CONSTRAINT [DF_Identity_IdentityId]  DEFAULT (newid()) FOR [IdentityId]
GO

ALTER TABLE [dbo].[Identities] ADD  CONSTRAINT [DF_Identities_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO


