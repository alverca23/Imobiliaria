CREATE TABLE [dbo].[funcionario] (
    [Id]       INT            NOT NULL,
    [Nome]     NVARCHAR (MAX) NULL,
    [Apelido]  NVARCHAR (MAX) NULL,
    [Email]    NVARCHAR (MAX) NULL,
    [Morada]   NVARCHAR (MAX) NULL,
    [NIF]      INT            NULL,
    [Telefone] INT            NULL,
    [Foto]     IMAGE          NULL,
    [Ativo]    BIT            NULL,
    CONSTRAINT [PK_funcionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

