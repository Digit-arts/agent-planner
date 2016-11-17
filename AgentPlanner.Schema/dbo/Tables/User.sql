CREATE TABLE [dbo].[User] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [FullName]         NVARCHAR (100)   NOT NULL,
    [MobileNumber]     NVARCHAR (50)    NOT NULL,
    [EmailAddress]     NVARCHAR (100)   NOT NULL,
    [Password]         NVARCHAR (256)   NOT NULL,
    [CreatedDate]      DATETIME         NOT NULL,
    [IsDeleted]        BIT              NOT NULL,
    [DeletedDate]      DATETIME         NULL,
    [PasswordResetKey] NVARCHAR (500)   NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

