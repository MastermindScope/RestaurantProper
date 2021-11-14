
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2021 10:05:52
-- Generated from EDMX file: C:\Users\Vinzenz Götz\Desktop\Uni\SE\RestaurantProper\RestaurantLibDB\RestaurantModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Restaurant];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GebuchtUm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zeitslots] DROP CONSTRAINT [FK_GebuchtUm];
GO
IF OBJECT_ID(N'[dbo].[FK_BuchungsZeit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bestellungen] DROP CONSTRAINT [FK_BuchungsZeit];
GO
IF OBJECT_ID(N'[dbo].[FK_EnthaeltGericht_Buchung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnthaeltGericht] DROP CONSTRAINT [FK_EnthaeltGericht_Buchung];
GO
IF OBJECT_ID(N'[dbo].[FK_EnthaeltGericht_Gericht]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnthaeltGericht] DROP CONSTRAINT [FK_EnthaeltGericht_Gericht];
GO
IF OBJECT_ID(N'[dbo].[FK_GebuchtVon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bestellungen] DROP CONSTRAINT [FK_GebuchtVon];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Filialen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Filialen];
GO
IF OBJECT_ID(N'[dbo].[Kunden]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kunden];
GO
IF OBJECT_ID(N'[dbo].[Bestellungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bestellungen];
GO
IF OBJECT_ID(N'[dbo].[Zeitslots]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zeitslots];
GO
IF OBJECT_ID(N'[dbo].[Gerichte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gerichte];
GO
IF OBJECT_ID(N'[dbo].[EnthaeltGericht]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EnthaeltGericht];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Filialen'
CREATE TABLE [dbo].[Filialen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Beschreibung] nvarchar(max)  NOT NULL,
    [Ort] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Kunden'
CREATE TABLE [dbo].[Kunden] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Kundennummer] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bestellungen'
CREATE TABLE [dbo].[Bestellungen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Buchungsnummmer] nvarchar(max)  NOT NULL,
    [Personen] smallint  NOT NULL,
    [ZeitslotId] int  NOT NULL,
    [KundeId] int  NOT NULL
);
GO

-- Creating table 'Zeitslots'
CREATE TABLE [dbo].[Zeitslots] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Start] datetime  NOT NULL,
    [Ende] datetime  NOT NULL,
    [Filiale_Id] int  NOT NULL
);
GO

-- Creating table 'Gerichte'
CREATE TABLE [dbo].[Gerichte] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Beschreibung] nvarchar(max)  NOT NULL,
    [Preis] float  NOT NULL
);
GO

-- Creating table 'EnthaeltGericht'
CREATE TABLE [dbo].[EnthaeltGericht] (
    [EnthaltenIn_Id] int  NOT NULL,
    [EnthaeltGerichte_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Filialen'
ALTER TABLE [dbo].[Filialen]
ADD CONSTRAINT [PK_Filialen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kunden'
ALTER TABLE [dbo].[Kunden]
ADD CONSTRAINT [PK_Kunden]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bestellungen'
ALTER TABLE [dbo].[Bestellungen]
ADD CONSTRAINT [PK_Bestellungen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zeitslots'
ALTER TABLE [dbo].[Zeitslots]
ADD CONSTRAINT [PK_Zeitslots]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Gerichte'
ALTER TABLE [dbo].[Gerichte]
ADD CONSTRAINT [PK_Gerichte]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EnthaltenIn_Id], [EnthaeltGerichte_Id] in table 'EnthaeltGericht'
ALTER TABLE [dbo].[EnthaeltGericht]
ADD CONSTRAINT [PK_EnthaeltGericht]
    PRIMARY KEY CLUSTERED ([EnthaltenIn_Id], [EnthaeltGerichte_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Filiale_Id] in table 'Zeitslots'
ALTER TABLE [dbo].[Zeitslots]
ADD CONSTRAINT [FK_GebuchtUm]
    FOREIGN KEY ([Filiale_Id])
    REFERENCES [dbo].[Filialen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GebuchtUm'
CREATE INDEX [IX_FK_GebuchtUm]
ON [dbo].[Zeitslots]
    ([Filiale_Id]);
GO

-- Creating foreign key on [ZeitslotId] in table 'Bestellungen'
ALTER TABLE [dbo].[Bestellungen]
ADD CONSTRAINT [FK_BuchungsZeit]
    FOREIGN KEY ([ZeitslotId])
    REFERENCES [dbo].[Zeitslots]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuchungsZeit'
CREATE INDEX [IX_FK_BuchungsZeit]
ON [dbo].[Bestellungen]
    ([ZeitslotId]);
GO

-- Creating foreign key on [EnthaltenIn_Id] in table 'EnthaeltGericht'
ALTER TABLE [dbo].[EnthaeltGericht]
ADD CONSTRAINT [FK_EnthaeltGericht_Buchung]
    FOREIGN KEY ([EnthaltenIn_Id])
    REFERENCES [dbo].[Bestellungen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EnthaeltGerichte_Id] in table 'EnthaeltGericht'
ALTER TABLE [dbo].[EnthaeltGericht]
ADD CONSTRAINT [FK_EnthaeltGericht_Gericht]
    FOREIGN KEY ([EnthaeltGerichte_Id])
    REFERENCES [dbo].[Gerichte]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnthaeltGericht_Gericht'
CREATE INDEX [IX_FK_EnthaeltGericht_Gericht]
ON [dbo].[EnthaeltGericht]
    ([EnthaeltGerichte_Id]);
GO

-- Creating foreign key on [KundeId] in table 'Bestellungen'
ALTER TABLE [dbo].[Bestellungen]
ADD CONSTRAINT [FK_GebuchtVon]
    FOREIGN KEY ([KundeId])
    REFERENCES [dbo].[Kunden]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GebuchtVon'
CREATE INDEX [IX_FK_GebuchtVon]
ON [dbo].[Bestellungen]
    ([KundeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------