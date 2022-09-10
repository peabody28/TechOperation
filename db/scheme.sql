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


ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleFk]) REFERENCES [dbo].[Role] ([Id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO