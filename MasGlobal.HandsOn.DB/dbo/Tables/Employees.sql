CREATE TABLE [dbo].[Employees] (
    [EmployeeId]     INT          IDENTITY (1, 1) NOT NULL,
    [DocumentTypeFk] INT          NOT NULL,
    [DocumentNumber] DECIMAL (18) NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [LastName]       VARCHAR (50) NULL,
    [PaymentValue]   DECIMAL (18) NOT NULL,
    [ContractTypeFk] INT          NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

