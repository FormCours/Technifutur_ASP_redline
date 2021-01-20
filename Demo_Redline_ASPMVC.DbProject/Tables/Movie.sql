CREATE TABLE [dbo].[Movie]
(
	[Id_Movie] BIGINT IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[Resume] NVARCHAR(4000),
	[Duration] INT,
	[ReleaseDate] DATE,
	[Id_ProductionCompany] BIGINT NOT NULL,
	CONSTRAINT [PK_Movie] PRIMARY KEY([Id_Movie]),
	CONSTRAINT [FK_Movie_ProductionCompany]
	  FOREIGN KEY([Id_ProductionCompany]) REFERENCES [ProductionCompany]([Id_ProductionCompany])
)
