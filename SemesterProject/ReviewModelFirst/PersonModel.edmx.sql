
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2016 09:29:35
-- Generated from EDMX file: C:\Users\Jeanette\Source\Repos\C-SemesterProject\SemesterProject\ReviewModelFirst\PersonModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SCHOOLDBREVIEW];
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

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstMidName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NULL
);
GO

-- Creating table 'PersonSet_Teacher'
CREATE TABLE [dbo].[PersonSet_Teacher] (
    [HireDate] datetime  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PersonSet_Student'
CREATE TABLE [dbo].[PersonSet_Student] (
    [EnrollmentDate] datetime  NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Teacher'
ALTER TABLE [dbo].[PersonSet_Teacher]
ADD CONSTRAINT [PK_PersonSet_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Student'
ALTER TABLE [dbo].[PersonSet_Student]
ADD CONSTRAINT [PK_PersonSet_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id] in table 'PersonSet_Teacher'
ALTER TABLE [dbo].[PersonSet_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonSet_Student'
ALTER TABLE [dbo].[PersonSet_Student]
ADD CONSTRAINT [FK_Student_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------