CREATE TABLE [dbo].[DocumentTypes] (
    [DocumentTypeId]   INT          IDENTITY (1, 1) NOT NULL,
    [DocumentTypeName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED ([DocumentTypeId] ASC)
);

