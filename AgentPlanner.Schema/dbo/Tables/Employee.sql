CREATE TABLE [dbo].[Employee] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeCode]     NVARCHAR (20)  NOT NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [Address]          NVARCHAR (100) NULL,
    [Address2]         NVARCHAR (100) NULL,
    [ZipCode]          NVARCHAR (5)   NOT NULL,
    [City]             NVARCHAR (50)  NOT NULL,
    [PhoneNumber]      NVARCHAR (18)  NOT NULL,
    [EmailAddress]     NVARCHAR (50)  NOT NULL,
    [PhotoResouceId]   INT            NOT NULL,
    [DateOfBirth]      DATE           NOT NULL,
    [Comments]         NVARCHAR (255) NULL,
    [IsActive]         BIT            NOT NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [IsDeleted]        BIT            NOT NULL,
    [DeletedDate]      DATETIME       NULL,
    [ModificationDate] DATETIME       NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_Resource] FOREIGN KEY ([PhotoResouceId]) REFERENCES [dbo].[Resource] ([Id])
);



