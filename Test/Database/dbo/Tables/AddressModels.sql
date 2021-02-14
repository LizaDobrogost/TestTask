CREATE TABLE [dbo].[AddressModels] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Country]    NVARCHAR (MAX) NOT NULL,
    [OfficeName] NVARCHAR (MAX) NOT NULL,
    [Address]    NVARCHAR (MAX) NOT NULL,
    [PostalCode] NVARCHAR (MAX) NOT NULL,
    [City]       NVARCHAR (MAX) NOT NULL,
    [State]      NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_AddressModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

