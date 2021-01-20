CREATE TABLE [dbo].[Member]
(
	[Id_Member] BIGINT NOT NULL, 
    [Pseudo] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(250) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Id_Role] BIGINT NOT NULL, 
    CONSTRAINT [PK_Member] PRIMARY KEY ([Id_Member]), 
    CONSTRAINT [UK_Member_Pseudo] UNIQUE ([Pseudo]), 
    CONSTRAINT [UK_Member_Email] UNIQUE ([Email]), 
    CONSTRAINT [FK_Member_Role] FOREIGN KEY ([Id_Role]) REFERENCES [Role]([Id_Role]) 
)
