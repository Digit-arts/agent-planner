CREATE TABLE [dbo].[Contract] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [SiteId]                    INT            NOT NULL,
    [StartDate]                 DATE           NOT NULL,
    [EndDate]                   DATE           NOT NULL,
    [ContractTypeId]            TINYINT        NOT NULL,
    [BillingRate]               FLOAT (53)     NOT NULL,
    [BillingFrequencyId]        TINYINT        NOT NULL,
    [Comments]                  NVARCHAR (255) NULL,
    [IsActive]                  BIT            NOT NULL,
    [NightTimeRateIncrease]     BIT            NOT NULL,
    [SundayRateIncrease]        BIT            NOT NULL,
    [PublicHolidayRateIncrease] BIT            NOT NULL,
    [AssignmentTypeId]          TINYINT        NOT NULL,
    [IsDeleted]                 BIT            NOT NULL,
    [CreatedDate]               DATETIME       NOT NULL,
    [ModifiedDate]              DATETIME       NULL,
    [DeletedDate]               DATETIME       NULL,
    CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contract_AssignmentType] FOREIGN KEY ([AssignmentTypeId]) REFERENCES [dbo].[AssignmentType] ([Id]),
    CONSTRAINT [FK_Contract_BillingFrequency] FOREIGN KEY ([BillingFrequencyId]) REFERENCES [dbo].[BillingFrequency] ([Id]),
    CONSTRAINT [FK_Contract_ContractType] FOREIGN KEY ([ContractTypeId]) REFERENCES [dbo].[ContractType] ([Id]),
    CONSTRAINT [FK_Contract_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([Id])
);



