CREATE TABLE [dbo].[Table] (
    [Id]         INT          NOT NULL IDENTITY,
    [usuario]    VARCHAR (50) NOT NULL,
    [contrasena] VARCHAR (50) NOT NULL,
    [tipo]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

