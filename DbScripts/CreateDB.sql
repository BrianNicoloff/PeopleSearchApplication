USE master
GO

IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'PeopleSearchApplication')
BEGIN
	Print '----------------------------------------------------------------------------------------------'
	Print 'Dropping Database'
	Print '----------------------------------------------------------------------------------------------'
	ALTER DATABASE [PeopleSearchApplication)] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [PeopleSearchApplication];
END

Print '----------------------------------------------------------------------------------------------'
Print 'Creating Database'
Print '----------------------------------------------------------------------------------------------'
CREATE DATABASE [PeopleSearchApplication]
GO

ALTER DATABASE [PeopleSearchApplication] SET MULTI_USER WITH ROLLBACK IMMEDIATE;
GO

Print '----------------------------------------------------------------------------------------------'
Print 'Adding Logins to system'
Print '----------------------------------------------------------------------------------------------'

IF NOT EXISTS (SELECT NULL FROM sys.syslogins WHERE name = N'peoplesearchuser')
	CREATE LOGIN [peoplesearchuser] WITH PASSWORD = N'SuperSecretPassword!'
GO

-----------------------------------------------------------------------------------------------------
USE [PeopleSearchApplication]
GO
-----------------------------------------------------------------------------------------------------

Print '----------------------------------------------------------------------------------------------'
Print 'Adding Users to Database'
Print '----------------------------------------------------------------------------------------------'

CREATE USER [peoplesearchuser] FOR LOGIN [peoplesearchuser]   
    WITH DEFAULT_SCHEMA = dbo;  
GO  

EXEC sp_addrolemember 'db_owner', 'peoplesearchuser';


Print '----------------------------------------------------------------------------------------------'
Print 'Adding People Table'
Print '----------------------------------------------------------------------------------------------'

CREATE TABLE [dbo].[People](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Name] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[ImagePath] [nvarchar](200) NOT NULL,
	[Interests] [nvarchar](500) NOT NULL
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED
 (
	[Id] ASC
 )
) ON [PRIMARY]

GO