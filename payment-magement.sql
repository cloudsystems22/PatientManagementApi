-- Criação do banco de dados, se não existir
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'PatientManagementDb')
BEGIN
    CREATE DATABASE [PatientManagementDb];
END
GO

-- Seleciona o banco de dados criado
USE [PatientManagementDb];
GO

-- Criação da tabela 'Speciality'
CREATE TABLE [Speciality] (
    [Id] nvarchar(6) NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Speciality] PRIMARY KEY ([Id])
);
GO

-- Criação da tabela 'Patient'
CREATE TABLE [Patient] (
    [Id] nvarchar(8) NOT NULL,
    [Rg] nvarchar(10) NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [Phone] nvarchar(11) NOT NULL,
    [Sex] int NOT NULL,
    [EmailAddress] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY ([Id])
);
GO

-- Criação da tabela 'Care'
CREATE TABLE [Care] (
    [Id] nvarchar(8) NOT NULL,
    [SequenceNumber] nvarchar(4) NOT NULL,
    [PatientId] nvarchar(8) NOT NULL,
    [ArrivalTime] datetime2 NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Care] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Care_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patient] ([Id]) ON DELETE CASCADE
);
GO

-- Criação da tabela 'Triage'
CREATE TABLE [Triage] (
    [Id] nvarchar(8) NOT NULL,
    [CareId] nvarchar(8) NOT NULL,
    [Symptoms] nvarchar(max) NOT NULL,
    [BloodPressure] nvarchar(max) NOT NULL,
    [Weight] decimal(18,2) NOT NULL,
    [Height] decimal(18,2) NOT NULL,
    [SpecialityId] nvarchar(6) NOT NULL,
    CONSTRAINT [PK_Triage] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Triage_CareId] FOREIGN KEY ([CareId]) REFERENCES [Care] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Triage_SpecialityId] FOREIGN KEY ([SpecialityId]) REFERENCES [Speciality] ([Id]) ON DELETE CASCADE
);
GO

-- Criação de índices para FKs
CREATE INDEX [IX_Care_PatientId] ON [Care] ([PatientId]);
GO

CREATE UNIQUE INDEX [IX_Triage_CareId] ON [Triage] ([CareId]);
GO

CREATE INDEX [IX_Triage_SpecialityId] ON [Triage] ([SpecialityId]);
GO
