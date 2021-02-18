﻿CREATE TABLE [dbo].[Role]
(
	[Id_Role] BIGINT NOT NULL IDENTITY , 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id_Role]),
    CONSTRAINT [UK_Role] UNIQUE([Name])
)
