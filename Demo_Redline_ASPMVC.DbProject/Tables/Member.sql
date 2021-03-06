﻿CREATE TABLE [dbo].[Member]
(
	[Id_Member] BIGINT IDENTITY, 
    [Pseudo] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(250) NOT NULL, 
    [Id_Role] BIGINT NOT NULL, 
    [Password] VARBINARY(64) NOT NULL,
    [Salt] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY ([Id_Member]), 
    CONSTRAINT [UK_Member_Pseudo] UNIQUE ([Pseudo]), 
    CONSTRAINT [UK_Member_Email] UNIQUE ([Email]), 
    CONSTRAINT [FK_Member_Role] FOREIGN KEY ([Id_Role]) REFERENCES [Role]([Id_Role]) 
)
