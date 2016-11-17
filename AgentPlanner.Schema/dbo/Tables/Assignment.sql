CREATE TABLE [dbo].[Assignment] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [AssignmentTypeId] TINYINT  NOT NULL,
    [ContractId]       INT      NOT NULL,
    [EmployeeId]       INT      NOT NULL,
    [StartDateTime]    DATETIME NOT NULL,
    [EndDateTime]      DATETIME NOT NULL,
    [IsDeleted]        BIT      NOT NULL,
    CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Assignment_AssignmentType] FOREIGN KEY ([AssignmentTypeId]) REFERENCES [dbo].[AssignmentType] ([Id]),
    CONSTRAINT [FK_Assignment_Contract] FOREIGN KEY ([ContractId]) REFERENCES [dbo].[Contract] ([Id]),
    CONSTRAINT [FK_Assignment_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);



