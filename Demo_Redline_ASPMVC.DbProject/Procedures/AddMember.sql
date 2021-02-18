CREATE PROCEDURE [dbo].[AddMember]
	@Pseudo NVARCHAR(50),
	@Email NVARCHAR(250),
	@Password NVARCHAR(50)
AS
BEGIN
   SET NOCOUNT ON;

   -- Génération du sel.
   DECLARE @Salt UNIQUEIDENTIFIER;
   SET @Salt = NEWID();

   -- Hashage du mot de passe
   DECLARE @Hash_Password VARBINARY(64);
   SET @Hash_Password = HASHBYTES('SHA2_512', CONCAT(@Password, @Salt));

   -- Récuperation du role de type "member"
   DECLARE @Id_Role_Nember BIGINT;
   SELECT @Id_Role_Nember = Id_Role FROM [dbo].[Role] WHERE  [Name] LIKE 'Member';

   -- Ajout en base de donnée avec un retour via l'output
   INSERT INTO [dbo].[Member] ([Pseudo], [Email], [Id_Role], [Password], [Salt])
    OUTPUT inserted.Id_Member, inserted.Pseudo, inserted.Email, inserted.Id_Role
    VALUES (@Pseudo, @Email, @Id_Role_Nember, @Hash_Password, @Salt);

END