CREATE TABLE [dbo].[SiteEmployeeType] (
    [Id]             INT     IDENTITY (1, 1) NOT NULL,
    [SiteId]         INT     NOT NULL,
    [EmployeeTypeId] TINYINT NOT NULL,
    CONSTRAINT [PK_SiteEmployeeTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SiteEmployeeTypeEmployeeType] FOREIGN KEY ([EmployeeTypeId]) REFERENCES [dbo].[EmployeeType] ([Id]),
    CONSTRAINT [FK_SiteEmployeeTypeSite] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([Id])
);

