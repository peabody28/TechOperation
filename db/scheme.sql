IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'tech.operations')
BEGIN
    CREATE DATABASE [tech.operations]
END
GO

USE [tech.operations]
GO

/* Role */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE [object_id] = object_id('Role'))
BEGIN
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	PRIMARY KEY ([Id])) 
END
GO

/* User */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE [object_id] = object_id('User'))
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[TelegramId] [int] NULL,
	[Name] [varchar](50) NULL,
	[RoleFk] [uniqueidentifier] NOT NULL,
	[PhoneNumber] [varchar](50) NULL,
	PRIMARY KEY ([Id]))
END
GO

IF (OBJECT_ID('dbo.FK_User_Role', 'F') IS NULL)
BEGIN
    ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleFk]) REFERENCES [dbo].[Role] ([Id])
END
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO

/* Event */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE [object_id] = object_id('Event'))
BEGIN
CREATE TABLE [dbo].[Event](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [text] NOT NULL,
	[RoleFk] [uniqueidentifier] NULL,
	PRIMARY KEY ([Id]))
END
GO

IF (OBJECT_ID('dbo.FK_Event_Role', 'F') IS NULL)
BEGIN
    ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Role] FOREIGN KEY([RoleFk]) REFERENCES [dbo].[Role] ([Id])
END
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Role]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'IsConfirmed'AND Object_ID = Object_ID(N'dbo.Event'))
BEGIN
	ALTER TABLE [dbo].[Event] ADD [IsConfirmed] bit NOT NULL DEFAULT(0)
END
GO

ALTER TABLE [dbo].[Event] ALTER COLUMN [Title] [varchar](255)
