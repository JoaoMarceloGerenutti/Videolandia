CREATE DATABASE dbVideolandia
GO

USE dbVideolandia
GO

CREATE TABLE Clientes (
	Email VARCHAR(120) PRIMARY KEY,
	Nome VARCHAR(120) NOT NULL,
	Senha VARCHAR(32) NOT NULL
)
GO

CREATE TABLE Mensagens (
    CodigoMensagem INT PRIMARY KEY IDENTITY,
    Email VARCHAR(120) NOT NULL,
    Assunto VARCHAR(120) NOT NULL,
	Texto VARCHAR(300) NOT NULL,
    DataEnvio DATETIME NOT NULL,

    CONSTRAINT FK_Email FOREIGN KEY (Email) REFERENCES Clientes(Email)
)
GO

CREATE TABLE Items (
    Codigo INT PRIMARY KEY IDENTITY,
    CodigoBarra VARCHAR(13) UNIQUE NOT NULL,
    Titulo VARCHAR(120) NOT NULL,
    CodigoGenero INT UNIQUE NULL,
    Lancamento DATE NOT NULL,
    Tipo BIT NOT NULL,
    Preco FLOAT  NOT NULL,
    DataAquisicao DATETIME NOT NULL,
    Valor FLOAT NOT NULL,
    Situacao BIT NOT NULL, 
    CodigoArtista INT UNIQUE NULL,
    Diretor VARCHAR (120) NOT NULL,
    Capa VARCHAR(MAX) NOT NULL
)
GO

CREATE TABLE Generos (
    CodigoGenero INT PRIMARY KEY IDENTITY NOT NULL,
    NomeGenero VARCHAR(120) NOT NULL
)
GO

CREATE TABLE Artistas (
    CodigoArtista INT PRIMARY KEY IDENTITY NOT NULL,
    NomeArtista VARCHAR(120) NOT NULL,
    DataNascimento DATE  NOT NULL,
    PaisNascimento VARCHAR(32) NOT NULL,
    Foto VARCHAR(MAX) NOT NULL
)
GO

CREATE TABLE Contem (
    CodigoItem INT NOT NULL,
    CodigoGenero INT NOT NULL,
    FOREIGN KEY (CodigoItem) REFERENCES Items(Codigo),
    FOREIGN KEY (CodigoGenero) REFERENCES Generos(CodigoGenero)
)
GO

CREATE TABLE Atua (
    CodigoItem INT NOT NULL,
    CodigoArtista INT NOT NULL,
    NomePersonagem VARCHAR(120) NOT NULL,
    FOREIGN KEY (CodigoItem) REFERENCES Items(Codigo),
    FOREIGN KEY (CodigoArtista) REFERENCES Artistas(CodigoArtista)
)
GO

DROP TABLE Mensagens
GO
DROP TABLE Items
GO
DROP TABLE Generos
GO
DROP TABLE Artistas
GO
DROP TABLE Contem
GO
DROP TABLE Atua
GO

SELECT * FROM Items

SELECT * FROM Items WHERE Codigo = 1

SELECT * FROM Items ORDER BY DataAquisicao DESC

SELECT MAX(Codigo) AS Codigo FROM Items

SELECT COUNT(CodigoGenero) AS Quantidade FROM Generos;

DELETE FROM Items WHERE Codigo = 1;

SELECT * FROM Items ORDER BY DataInsercao
SELECT * FROM Items WHERE Titulo LIKE '%The%'
SELECT * FROM Artistas WHERE NomeArtista LIKE '%a%' ORDER BY NomeArtista
SELECT * FROM Items WHERE Diretor LIKE '%o%' ORDER BY Diretor

INSERT INTO Generos VALUES ('Ação')
INSERT INTO Generos VALUES ('Aventura')
INSERT INTO Generos VALUES ('Terror')
INSERT INTO Generos VALUES ('Romance')
INSERT INTO Generos VALUES ('Ficção Científica')
INSERT INTO Generos VALUES ('Fantasia')

INSERT INTO Artistas VALUES ('Nicolas Cage', CONVERT(DATE,'1964-01-07'), 'Estado Unidos', 'C:')
GO
INSERT INTO Artistas VALUES ('Brad Pitt', CONVERT(DATE,'1963-12-18'), 'Estado Unidos', 'C:')
GO
INSERT INTO Artistas VALUES ('Adam Sandler', CONVERT(DATE,'1966-09-09'), 'Estado Unidos', 'C:')
GO
INSERT INTO Artistas VALUES ('Leonardo DiCaprio', CONVERT(DATE,'1974-11-11'), 'Estado Unidos', 'C:')
GO
INSERT INTO Artistas VALUES ('Will Smith', CONVERT(DATE,'1968-09-25'), 'Estado Unidos', 'C:')
GO
INSERT INTO Artistas VALUES ('Keanu Reeves', CONVERT(DATE,'1964-09-02'), 'Líbano', 'C:')
GO
INSERT INTO Artistas VALUES ('Arnold Schwarzenegger', CONVERT(DATE,'1947-07-30'), 'Áustria', 'C:')
GO
INSERT INTO Artistas VALUES ('Matt Damon', CONVERT(DATE,'1970-10-08'), 'Estado Unidos', 'C:')
GO
INSERT INTO Artistas VALUES ('Eddie Murphy', CONVERT(DATE,'1961-04-03'), 'Estado Unidos', 'C:')
GO
INSERT INTO Artistas VALUES ('Reese Witherspoon', CONVERT(DATE,'1976-03-22'), 'Estado Unidos', 'C:')
GO

INSERT INTO Contem VALUES ('1', '1')
INSERT INTO Contem VALUES ('1', '2')
INSERT INTO Contem VALUES ('1', '3')
INSERT INTO Contem VALUES ('1', '4')

INSERT INTO Atua VALUES ('1', '1', 'Sonic')
INSERT INTO Atua VALUES ('1', '2', 'Kleber')

SELECT * FROM Mensagens
SELECT * FROM Clientes
SELECT * FROM Artistas
SELECT * FROM Generos

INSERT INTO Clientes VALUES ('admin@admin.com', 'admin', '0192023a7bbd73250516f069df18b500')

SELECT * FROM Contem
DELETE FROM Contem WHERE CodigoItem = 1

SELECT * FROM Atua
DELETE FROM Atua WHERE CodigoItem = 1

SELECT Items.Codigo, Generos.NomeGenero AS Generos
FROM Contem
INNER JOIN Generos ON Contem.CodigoGenero = Generos.CodigoGenero
INNER JOIN Items ON Contem.CodigoItem = Items.Codigo
WHERE Codigo = 1

SELECT Artistas.CodigoArtista AS Codigo, Artistas.NomeArtista AS Nome
FROM Atua
INNER JOIN Artistas ON Atua.CodigoArtista = Artistas.CodigoArtista
INNER JOIN Items ON Atua.CodigoItem = Items.Codigo
WHERE Codigo = 1

SELECT Items.Codigo, Items.Titulo, Artistas.NomeArtista AS Nome, Atua.NomePersonagem AS Personagem
FROM Atua
JOIN Artistas ON Atua.CodigoArtista = Artistas.CodigoArtista
JOIN Items ON Atua.CodigoItem = Items.Codigo

SELECT Items.Codigo, Items.Titulo, Generos.NomeGenero AS Generos, Artistas.NomeArtista AS Artistas FROM ((Items
INNER JOIN Generos ON Items.CodigoGenero = Generos.CodigoGenero)
INNER JOIN Artistas ON Items.CodigoArtista = Artistas.CodigoArtista)

DELETE FROM Generos WHERE CodigoGenero = 2

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Nicolas Cage.png' WHERE CodigoArtista = 1

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Brad Pitt.png' WHERE CodigoArtista = 2

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Adam Sandler.png' WHERE CodigoArtista = 3

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Leonardo DiCaprio.png' WHERE CodigoArtista = 4

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Will Smith.png' WHERE CodigoArtista = 5

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Keanu Reeves.png' WHERE CodigoArtista = 6

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Arnold Schwarzenegger.png' WHERE CodigoArtista = 7

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Matt Damon.png' WHERE CodigoArtista = 8

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Eddie Murphy.png' WHERE CodigoArtista = 9

UPDATE Artistas SET Foto =
'~/Imagens/Upload/Atores/Reese Witherspoon.png' WHERE CodigoArtista = 10

