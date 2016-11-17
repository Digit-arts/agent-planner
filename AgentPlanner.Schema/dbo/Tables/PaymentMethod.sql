CREATE TABLE [dbo].[PaymentMethod] (
    [Id]         TINYINT       NOT NULL,
    [MethodName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentMethod] PRIMARY KEY CLUSTERED ([Id] ASC)
);

