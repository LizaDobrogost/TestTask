CREATE TABLE [dbo].[Users] (
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
    [Comments]   NVARCHAR (MAX) NOT NULL,
    [Country]    NVARCHAR (MAX) NOT NULL,
    [OfficeName] NVARCHAR (MAX) NOT NULL,
    [Address]    NVARCHAR (MAX) NOT NULL,
    [PostalCode] NVARCHAR (MAX) NOT NULL,
    [City]       NVARCHAR (MAX) NOT NULL,
    [State]      NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

