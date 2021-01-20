CREATE TABLE [dbo].[Movie_Genre]
(
	[Id_MovieGenre] BIGINT IDENTITY,  
	[Id_Movie] BIGINT NOT NULL, 
    [Id_Genre] BIGINT NOT NULL,
	CONSTRAINT PK_MovieGenre PRIMARY KEY([Id_MovieGenre]),
	CONSTRAINT UK_MovieGenre UNIQUE([Id_Movie], [Id_Genre]),
	CONSTRAINT FK_MovieGenre_Movie
	  FOREIGN KEY([Id_Movie]) REFERENCES [Movie]([Id_Movie]),
	CONSTRAINT FK_MovieGenre_Genre
	  FOREIGN KEY([Id_Genre]) REFERENCES [Genre]([Id_Genre])
)
