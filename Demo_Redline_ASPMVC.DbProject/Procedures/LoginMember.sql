CREATE PROCEDURE [dbo].[LoginMember]
	@login NVARCHAR(250),
	@Password NVARCHAR(50)
AS
BEGIN
   SET NOCOUNT ON;

   -- Récuperation de l'Id_member et le sel sur base de l'info "login"
   DECLARE @Id_Member BIGINT, @Salt VARCHAR(50);
   SELECT @Id_Member = [Id_Member], @Salt = [Salt]
    FROM [dbo].[Member] 
	WHERE (Email LIKE @login OR Pseudo LIKE @login);

   -- Si un élément est trouvé, on vérifie le mot de passe
   IF (@Id_Member IS NOT NULL)
    BEGIN
	  -- Hashage du mot de passe reçu
	  DECLARE @Hash_Password VARBINARY(64);
	  SET @Hash_Password = HASHBYTES('SHA2_512', CONCAT(@Password, @Salt));

	  -- Renvoie du member sur base du login et du mot de passe hashé
	  SELECT Id_Member, Pseudo, Email, Id_Role
	   FROM [dbo].[Member]
	   WHERE (Email LIKE @login OR Pseudo LIKE @login) AND Password = @Hash_Password;

	END
END

