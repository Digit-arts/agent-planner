
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/17/2016 11:34:05
-- Generated from EDMX file: C:\Users\Ebimie\Documents\Visual Studio 2015\Projects\DynamIT Solutions\AgentPlanner\AgentPlanner.DataAccess\AgentPlanner.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AgentPlanner];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Assignment_AssignmentType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assignment] DROP CONSTRAINT [FK_Assignment_AssignmentType];
GO
IF OBJECT_ID(N'[dbo].[FK_Assignment_Contract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assignment] DROP CONSTRAINT [FK_Assignment_Contract];
GO
IF OBJECT_ID(N'[dbo].[FK_Assignment_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assignment] DROP CONSTRAINT [FK_Assignment_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Client_PaymentMethod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_Client_PaymentMethod];
GO
IF OBJECT_ID(N'[dbo].[FK_Contract_AssignmentType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_AssignmentType];
GO
IF OBJECT_ID(N'[dbo].[FK_Contract_BillingFrequency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_BillingFrequency];
GO
IF OBJECT_ID(N'[dbo].[FK_Contract_ContractType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_ContractType];
GO
IF OBJECT_ID(N'[dbo].[FK_Contract_Site]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK_Contract_Site];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Resource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Resource];
GO
IF OBJECT_ID(N'[dbo].[FK_Site_Client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Site] DROP CONSTRAINT [FK_Site_Client];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Assignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assignment];
GO
IF OBJECT_ID(N'[dbo].[AssignmentType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssignmentType];
GO
IF OBJECT_ID(N'[dbo].[BillingFrequency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillingFrequency];
GO
IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Contract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contract];
GO
IF OBJECT_ID(N'[dbo].[ContractType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractType];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO
IF OBJECT_ID(N'[dbo].[PaymentMethod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentMethod];
GO
IF OBJECT_ID(N'[dbo].[Resource]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Resource];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Site]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Site];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientCode] nvarchar(20)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(100)  NULL,
    [Address2] nvarchar(100)  NULL,
    [ZipCode] nvarchar(5)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [VatNumber] nvarchar(20)  NOT NULL,
    [ContactName] nvarchar(100)  NULL,
    [ContactPhoneNumber] nvarchar(18)  NULL,
    [EmailAddress] nvarchar(50)  NOT NULL,
    [PaymentMethodId] tinyint  NOT NULL,
    [Comments] nvarchar(255)  NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [DeletedDate] datetime  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModificationDate] datetime  NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Application] nvarchar(50)  NOT NULL,
    [Logged] datetime  NOT NULL,
    [Level] nvarchar(50)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(250)  NULL,
    [ServerName] nvarchar(max)  NULL,
    [Port] nvarchar(max)  NULL,
    [Url] nvarchar(max)  NULL,
    [Https] bit  NULL,
    [ServerAddress] nvarchar(100)  NULL,
    [RemoteAddress] nvarchar(100)  NULL,
    [Logger] nvarchar(250)  NULL,
    [Callsite] nvarchar(max)  NULL,
    [Exception] nvarchar(max)  NULL
);
GO

-- Creating table 'PaymentMethods'
CREATE TABLE [dbo].[PaymentMethods] (
    [Id] tinyint  NOT NULL,
    [MethodName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Resources'
CREATE TABLE [dbo].[Resources] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResourceName] nvarchar(100)  NOT NULL,
    [ResourcePath] nvarchar(255)  NOT NULL,
    [ResourceType] nvarchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ResourceExtenstion] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] tinyint  NOT NULL,
    [RoleName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Sites'
CREATE TABLE [dbo].[Sites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientId] int  NOT NULL,
    [SideCode] nvarchar(20)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(100)  NULL,
    [Address2] nvarchar(100)  NULL,
    [ZipCode] nvarchar(5)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [ContactName] nvarchar(100)  NULL,
    [ContactPhoneNumber] nvarchar(18)  NULL,
    [EmailAddress] nvarchar(50)  NOT NULL,
    [Comments] nvarchar(255)  NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [DeletedDate] datetime  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModificationDate] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] uniqueidentifier  NOT NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [MobileNumber] nvarchar(50)  NOT NULL,
    [EmailAddress] nvarchar(100)  NOT NULL,
    [Password] nvarchar(256)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [DeletedDate] datetime  NULL,
    [PasswordResetKey] nvarchar(500)  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [RoleId] tinyint  NOT NULL
);
GO

-- Creating table 'Assignments'
CREATE TABLE [dbo].[Assignments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AssignmentTypeId] tinyint  NOT NULL,
    [ContractId] int  NOT NULL,
    [EmployeeId] int  NOT NULL,
    [StartDateTime] datetime  NOT NULL,
    [EndDateTime] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'AssignmentTypes'
CREATE TABLE [dbo].[AssignmentTypes] (
    [Id] tinyint  NOT NULL,
    [TypeName] nvarchar(50)  NOT NULL,
    [DefaultBillingRate] float  NOT NULL
);
GO

-- Creating table 'BillingFrequencies'
CREATE TABLE [dbo].[BillingFrequencies] (
    [Id] tinyint  NOT NULL,
    [Frequency] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [ContractTypeId] tinyint  NOT NULL,
    [BillingRate] float  NOT NULL,
    [BillingFrequencyId] tinyint  NOT NULL,
    [Comments] nvarchar(255)  NULL,
    [IsActive] bit  NOT NULL,
    [NightTimeRateIncrease] bit  NOT NULL,
    [SundayRateIncrease] bit  NOT NULL,
    [PublicHolidayRateIncrease] bit  NOT NULL,
    [AssignmentTypeId] tinyint  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [DeletedDate] datetime  NULL
);
GO

-- Creating table 'ContractTypes'
CREATE TABLE [dbo].[ContractTypes] (
    [Id] tinyint  NOT NULL,
    [TypeName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeCode] nvarchar(20)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Address] nvarchar(100)  NULL,
    [Address2] nvarchar(100)  NULL,
    [ZipCode] nvarchar(5)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(18)  NOT NULL,
    [EmailAddress] nvarchar(50)  NOT NULL,
    [PhotoResouceId] int  NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Comments] nvarchar(255)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [DeletedDate] datetime  NULL,
    [ModificationDate] datetime  NULL,
    [EmployeeTypeId] tinyint  NOT NULL
);
GO

-- Creating table 'EmployeeTypes'
CREATE TABLE [dbo].[EmployeeTypes] (
    [Id] tinyint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentMethods'
ALTER TABLE [dbo].[PaymentMethods]
ADD CONSTRAINT [PK_PaymentMethods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Resources'
ALTER TABLE [dbo].[Resources]
ADD CONSTRAINT [PK_Resources]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sites'
ALTER TABLE [dbo].[Sites]
ADD CONSTRAINT [PK_Sites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [PK_Assignments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AssignmentTypes'
ALTER TABLE [dbo].[AssignmentTypes]
ADD CONSTRAINT [PK_AssignmentTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BillingFrequencies'
ALTER TABLE [dbo].[BillingFrequencies]
ADD CONSTRAINT [PK_BillingFrequencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContractTypes'
ALTER TABLE [dbo].[ContractTypes]
ADD CONSTRAINT [PK_ContractTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeTypes'
ALTER TABLE [dbo].[EmployeeTypes]
ADD CONSTRAINT [PK_EmployeeTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PaymentMethodId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_Client_PaymentMethod]
    FOREIGN KEY ([PaymentMethodId])
    REFERENCES [dbo].[PaymentMethods]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Client_PaymentMethod'
CREATE INDEX [IX_FK_Client_PaymentMethod]
ON [dbo].[Clients]
    ([PaymentMethodId]);
GO

-- Creating foreign key on [ClientId] in table 'Sites'
ALTER TABLE [dbo].[Sites]
ADD CONSTRAINT [FK_Site_Client]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Site_Client'
CREATE INDEX [IX_FK_Site_Client]
ON [dbo].[Sites]
    ([ClientId]);
GO

-- Creating foreign key on [RoleId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Role'
CREATE INDEX [IX_FK_UserRole_Role]
ON [dbo].[UserRoles]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_User'
CREATE INDEX [IX_FK_UserRole_User]
ON [dbo].[UserRoles]
    ([UserId]);
GO

-- Creating foreign key on [AssignmentTypeId] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [FK_Assignment_AssignmentType]
    FOREIGN KEY ([AssignmentTypeId])
    REFERENCES [dbo].[AssignmentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Assignment_AssignmentType'
CREATE INDEX [IX_FK_Assignment_AssignmentType]
ON [dbo].[Assignments]
    ([AssignmentTypeId]);
GO

-- Creating foreign key on [ContractId] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [FK_Assignment_Contract]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Assignment_Contract'
CREATE INDEX [IX_FK_Assignment_Contract]
ON [dbo].[Assignments]
    ([ContractId]);
GO

-- Creating foreign key on [AssignmentTypeId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_Contract_AssignmentType]
    FOREIGN KEY ([AssignmentTypeId])
    REFERENCES [dbo].[AssignmentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contract_AssignmentType'
CREATE INDEX [IX_FK_Contract_AssignmentType]
ON [dbo].[Contracts]
    ([AssignmentTypeId]);
GO

-- Creating foreign key on [BillingFrequencyId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_Contract_BillingFrequency]
    FOREIGN KEY ([BillingFrequencyId])
    REFERENCES [dbo].[BillingFrequencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contract_BillingFrequency'
CREATE INDEX [IX_FK_Contract_BillingFrequency]
ON [dbo].[Contracts]
    ([BillingFrequencyId]);
GO

-- Creating foreign key on [ContractTypeId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_Contract_ContractType]
    FOREIGN KEY ([ContractTypeId])
    REFERENCES [dbo].[ContractTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contract_ContractType'
CREATE INDEX [IX_FK_Contract_ContractType]
ON [dbo].[Contracts]
    ([ContractTypeId]);
GO

-- Creating foreign key on [SiteId] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_Contract_Site]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Contract_Site'
CREATE INDEX [IX_FK_Contract_Site]
ON [dbo].[Contracts]
    ([SiteId]);
GO

-- Creating foreign key on [EmployeeId] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [FK_Assignment_Employee]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Assignment_Employee'
CREATE INDEX [IX_FK_Assignment_Employee]
ON [dbo].[Assignments]
    ([EmployeeId]);
GO

-- Creating foreign key on [PhotoResouceId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Resource]
    FOREIGN KEY ([PhotoResouceId])
    REFERENCES [dbo].[Resources]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Resource'
CREATE INDEX [IX_FK_Employee_Resource]
ON [dbo].[Employees]
    ([PhotoResouceId]);
GO

-- Creating foreign key on [EmployeeTypeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeTypeEmployee]
    FOREIGN KEY ([EmployeeTypeId])
    REFERENCES [dbo].[EmployeeTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTypeEmployee'
CREATE INDEX [IX_FK_EmployeeTypeEmployee]
ON [dbo].[Employees]
    ([EmployeeTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------