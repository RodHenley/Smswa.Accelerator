CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Firstname] NVARCHAR(50) NULL, 
    [Surname] NVARCHAR(50) NULL, 
    [Inactive] BIT NULL DEFAULT 0
)

CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL,
    [AddressTypeId] INT NULL, 
	[Line1] NVARCHAR(255) NULL, 
    [Line2] NVARCHAR(255) NULL, 
    [Suburb] NVARCHAR(50) NULL, 
    [Postcode] NVARCHAR(10) NULL, 
    [State] NVARCHAR(50) NULL, 
    [Country] NVARCHAR(50) NULL, 
    [Inactive] BIT NULL DEFAULT 0
)

CREATE TABLE [dbo].[AddressType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ShortName] NVARCHAR(255) NULL, 
    [Inactive] BIT NULL DEFAULT 0
)

CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL,
    [ContactTypeId] INT NULL, 
    [Value] NVARCHAR(255) NULL, 
    [Inactive] BIT NULL DEFAULT 0
)

CREATE TABLE [dbo].[ContactType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ShortName] NVARCHAR(255) NULL, 
    [Inactive] BIT NULL DEFAULT 0
)
