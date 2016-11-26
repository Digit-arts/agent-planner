CREATE TABLE [dbo].[Quotation] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [SiteId]                    INT            NOT NULL,
    [ClientId]                  INT            NOT NULL,
    [StartDate]                 DATE           NOT NULL,
    [EndDate]                   DATE           NOT NULL,
    [ContractTypeId]            TINYINT        NOT NULL,
    [BillingRate]               FLOAT (53)     NOT NULL,
    [BillingFrequencyId]        TINYINT        NOT NULL,
    [NightTimeRateIncrease]     BIT            NOT NULL,
    [SundayRateIncrease]        BIT            NOT NULL,
    [PublicHolidayRateIncrease] BIT            NOT NULL,
    [DateAdded]                 DATETIME       NOT NULL,
    [TotalHours]                FLOAT (53)     NOT NULL,
    [TotalCost]                 FLOAT (53)     NOT NULL,
    [HoursPerDay]               NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Quotation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Quotation_BillingFrequency] FOREIGN KEY ([BillingFrequencyId]) REFERENCES [dbo].[BillingFrequency] ([Id]),
    CONSTRAINT [FK_Quotation_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]),
    CONSTRAINT [FK_Quotation_ContractType] FOREIGN KEY ([ContractTypeId]) REFERENCES [dbo].[ContractType] ([Id]),
    CONSTRAINT [FK_Quotation_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([Id])
);



