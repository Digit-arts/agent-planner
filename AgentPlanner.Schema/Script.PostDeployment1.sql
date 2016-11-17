/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select * from [Role] where id = 1)
begin
	insert into [Role] Values (1, 'Admin' )
end

INSERT [AssignmentType] ([Id], [TypeName], [DefaultBillingRate]) VALUES (1, N'SECURITY AGENT', 2)
INSERT [AssignmentType] ([Id], [TypeName], [DefaultBillingRate]) VALUES (2, N'TRAINING', 2)
INSERT [AssignmentType] ([Id], [TypeName], [DefaultBillingRate]) VALUES (3, N'DOG TRAINER', 2)

INSERT [BillingFrequency] ([Id], [Frequency]) VALUES (1, N'HOURLY')
INSERT [BillingFrequency] ([Id], [Frequency]) VALUES (2, N'DAILY')
INSERT [BillingFrequency] ([Id], [Frequency]) VALUES (3, N'MONTHLY')

INSERT [ContractType] ([Id], [TypeName]) VALUES (1, N'GUARDING')
INSERT [ContractType] ([Id], [TypeName]) VALUES (2, N'INTERVENTION')
INSERT [ContractType] ([Id], [TypeName]) VALUES (3, N'PATROL')

INSERT [PaymentMethod] ([Id], [MethodName]) VALUES (1, N'CASH')
INSERT [PaymentMethod] ([Id], [MethodName]) VALUES (2, N'CHECK')
