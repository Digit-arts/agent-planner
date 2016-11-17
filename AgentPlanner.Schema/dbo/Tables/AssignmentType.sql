CREATE TABLE [dbo].[AssignmentType] (
    [Id]                 TINYINT       NOT NULL,
    [TypeName]           NVARCHAR (50) NOT NULL,
    [DefaultBillingRate] FLOAT (53)    CONSTRAINT [DF_AssignmentType_DefaultBillingRate] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AssignmentType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

