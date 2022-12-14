--CRIANDO BANCO
USE master
CREATE DATABASE TesteTecnicoDB

--CRIANDO TABELAS
USE TesteTecnicoDB
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [NomeCompleto] nvarchar(50) NOT NULL,
    [Cpf] nvarchar(14) NOT NULL,
    [Telefone] nvarchar(14) NOT NULL,
    [TelefoneCelular] nvarchar(15) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221029220554_Inicial', N'6.0.10');
GO

COMMIT;
GO