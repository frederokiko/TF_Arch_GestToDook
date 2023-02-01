﻿CREATE TABLE [dbo].[ToDo]
(
	[Id] INT NOT NULL IDENTITY,
	[Title] NVARCHAR(128) NOT NULL,
	[Done] BIT NOT NULL
		CONSTRAINT DF_ToDo_Done DEFAULT (0),
    CONSTRAINT [PK_ToDo] PRIMARY KEY ([Id]) 
)