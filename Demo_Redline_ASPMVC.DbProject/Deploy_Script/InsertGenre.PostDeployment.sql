INSERT INTO [Genre] ([Name])
 VALUES ('Action'),
		('Comedy'),
		('Drama'),
		('Fantasy'),
		('Horror'),
		('Mystery'),
		('Romance'),
		('Thriller'),
		('Western');

INSERT INTO [Role] ([Name])
 VALUES ('Admin'),
	    ('Modo'),
		('Seeder'),
		('Member');

EXEC [dbo].[AddMember] 
   @Pseudo = N'Admin',
   @Email = N'admin@movie.asp.be',
   @Password = N'TestASP1234=';

EXEC [dbo].[AddMember] N'Zaza', N'zaza@gmail.com', N'Test1234=';

UPDATE [dbo].[Member] 
 SET [Id_Role] = (SELECT [Id_Role] FROM [dbo].[Role] WHERE [Name] LIKE 'Admin')
 WHERE [Email] LIKE N'admin@movie.asp.be';

UPDATE [dbo].[Member] 
 SET [Id_Role] = (SELECT [Id_Role] FROM [dbo].[Role] WHERE [Name] LIKE 'Seeder')
 WHERE [Email] LIKE N'zaza@gmail.com';