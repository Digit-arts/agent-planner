CREATE TABLE [dbo].[Site] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ClientId]           INT            NOT NULL,
    [SideCode]           NVARCHAR (20)  NOT NULL,
    [Name]               NVARCHAR (50)  NOT NULL,
    [Address]            NVARCHAR (100) NULL,
    [Address2]           NVARCHAR (100) NULL,
    [ZipCode]            NVARCHAR (5)   NOT NULL,
    [City]               NVARCHAR (50)  NOT NULL,
    [ContactName]        NVARCHAR (100) NULL,
    [ContactPhoneNumber] NVARCHAR (18)  NULL,
    [EmailAddress]       NVARCHAR (50)  NOT NULL,
    [Comments]           NVARCHAR (255) NULL,
    [IsActive]           BIT            NOT NULL,
    [CreatedDate]        DATETIME       NOT NULL,
    [IsDeleted]          BIT            NOT NULL,
    [DeletedDate]        DATETIME       NULL,
    [ModificationDate]   DATETIME       NULL,
    CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Site_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);



