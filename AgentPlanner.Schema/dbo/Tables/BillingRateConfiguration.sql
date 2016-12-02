CREATE TABLE [dbo].[BillingRateConfiguration] (
    [Id]                          INT        NOT NULL,
    [NightTimePercentageIncrease] FLOAT (53) NOT NULL,
    [WeekendPercentageIncrease]   FLOAT (53) NOT NULL,
    [HolidayPercentageIncrease]   FLOAT (53) NOT NULL,
    CONSTRAINT [PK__BillingR__3214EC07E57FD7E7] PRIMARY KEY CLUSTERED ([Id] ASC)
);



