CREATE TABLE [dbo].[ContactInfoModels] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (MAX) NOT NULL,
    [MiddleName] NVARCHAR (MAX) NULL,
    [LastName]   NVARCHAR (MAX) NOT NULL,
    [Company]    NVARCHAR (MAX) NOT NULL,
    [Title]      NVARCHAR (MAX) NOT NULL,
    [Email]      NVARCHAR (MAX) NOT NULL,
    [Phone]      NVARCHAR (MAX) NOT NULL,
    [Fax]        NVARCHAR (MAX) NULL,
    [Mobile]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ContactInfoModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

