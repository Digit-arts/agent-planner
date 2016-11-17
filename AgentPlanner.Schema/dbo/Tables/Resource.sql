CREATE TABLE [dbo].[Resource] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ResourceName]       NVARCHAR (100) NOT NULL,
    [ResourcePath]       NVARCHAR (255) NOT NULL,
    [ResourceType]       NVARCHAR (50)  NOT NULL,
    [ResourceExtenstion] NVARCHAR (10)  NOT NULL,
    [CreatedDate]        DATETIME       NOT NULL,
    CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED ([Id] ASC)
);



