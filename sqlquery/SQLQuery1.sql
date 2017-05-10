CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Title] VARCHAR(50) NULL,
	[Location] VARCHAR(250),
	[EventDate] DateTime NULL,
	[EventTypeId] int NOT NULL,
	[Price] Decimal(5,2) NOT NULL
)

CREATE TABLE [dbo].[EventType]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Label] VARCHAR(250) NULL
)