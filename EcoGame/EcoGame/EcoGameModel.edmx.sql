
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/27/2018 19:16:18
-- Generated from EDMX file: C:\Users\Daniela\Documents\SEPTIMO2\WEB\RepoProyecto\EcoGame\EcoGame\EcoGameModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EcoGame];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Perfils'
CREATE TABLE [dbo].[Perfils] (
    [ProfileId] int IDENTITY(1,1) NOT NULL,
    [NameProfile] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [NameUser] nvarchar(max)  NOT NULL,
    [PswUser] nvarchar(max)  NOT NULL,
    [Perfil_ProfileId] int  NOT NULL
);
GO

-- Creating table 'Animals'
CREATE TABLE [dbo].[Animals] (
    [AnimalId] int IDENTITY(1,1) NOT NULL,
    [SoundAnimal] nvarchar(max)  NOT NULL,
    [DescAnimal] nvarchar(max)  NOT NULL,
    [ImgAnimal] nvarchar(max)  NOT NULL,
    [NameAnimal] nvarchar(max)  NOT NULL,
    [Ecosystem_EcosystemId] int  NOT NULL
);
GO

-- Creating table 'Ecosystems'
CREATE TABLE [dbo].[Ecosystems] (
    [EcosystemId] int IDENTITY(1,1) NOT NULL,
    [ImgEcosystem] nvarchar(max)  NOT NULL,
    [DescEcosystem] nvarchar(max)  NOT NULL,
    [NameEcosystem] nvarchar(max)  NOT NULL,
    [RegEcosystem] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProfileId] in table 'Perfils'
ALTER TABLE [dbo].[Perfils]
ADD CONSTRAINT [PK_Perfils]
    PRIMARY KEY CLUSTERED ([ProfileId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [AnimalId] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [PK_Animals]
    PRIMARY KEY CLUSTERED ([AnimalId] ASC);
GO

-- Creating primary key on [EcosystemId] in table 'Ecosystems'
ALTER TABLE [dbo].[Ecosystems]
ADD CONSTRAINT [PK_Ecosystems]
    PRIMARY KEY CLUSTERED ([EcosystemId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Perfil_ProfileId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_PerfilUser]
    FOREIGN KEY ([Perfil_ProfileId])
    REFERENCES [dbo].[Perfils]
        ([ProfileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilUser'
CREATE INDEX [IX_FK_PerfilUser]
ON [dbo].[Users]
    ([Perfil_ProfileId]);
GO

-- Creating foreign key on [Ecosystem_EcosystemId] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK_EcosystemAnimal]
    FOREIGN KEY ([Ecosystem_EcosystemId])
    REFERENCES [dbo].[Ecosystems]
        ([EcosystemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EcosystemAnimal'
CREATE INDEX [IX_FK_EcosystemAnimal]
ON [dbo].[Animals]
    ([Ecosystem_EcosystemId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------