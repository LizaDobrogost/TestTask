CREATE TABLE [dbo].[AreasModels] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Comments] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_AreasModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

