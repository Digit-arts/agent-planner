CREATE TABLE [dbo].[BillingFrequency] (
    [Id]        TINYINT       NOT NULL,
    [Frequency] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_BillingFrequency] PRIMARY KEY CLUSTERED ([Id] ASC)
);

