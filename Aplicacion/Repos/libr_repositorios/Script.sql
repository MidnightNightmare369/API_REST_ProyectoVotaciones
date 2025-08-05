IF EXISTS (SELECT name FROM sys.databases WHERE name = 'db_votaciones')
BEGIN
    DROP DATABASE db_votaciones;
END;

CREATE DATABASE db_votaciones;
GO

USE db_votaciones;
GO

CREATE TABLE Voters (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50),
    [Email] NVARCHAR(50), 
    [HasVoted] BIT
);

CREATE TABLE Candidates (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50),
    [Party] NVARCHAR(50), 
    Votes INT
);

CREATE TABLE Votes (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [VoterId] INT NOT NULL REFERENCES Voters(Id),
	[CandidateId] INT NOT NULL REFERENCES Candidates(Id)
);

/*

-- INSERTS DE PRUEBA CON 5 CANDIDATOS Y 10 VOTANTES 

--CANDIDATOS
INSERT INTO Candidates ([Name], [Party], [Votes]) VALUES ('Ana Torres', 'Partido Azul', 0);
INSERT INTO Candidates ([Name], [Party], [Votes]) VALUES ('Luis Ramírez', 'Partido Verde', 0);
INSERT INTO Candidates ([Name], [Party], [Votes]) VALUES ('Marta Rojas', 'Partido Rojo', 0);
INSERT INTO Candidates ([Name], [Party], [Votes]) VALUES ('Carlos Díaz', 'Partido Naranja', 0);
INSERT INTO Candidates ([Name], [Party], [Votes]) VALUES ('Elena Gómez', 'Partido Amarillo', 0);

--VOTANTES
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Juan Pérez', 'juan@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Laura Mendoza', 'laura@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Santiago Gómez', 'santiago@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Paula Ruiz', 'paula@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Andrés López', 'andres@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('María Torres', 'maria@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Diego Castro', 'diego@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Natalia Silva', 'natalia@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Camilo Ramírez', 'camilo@example.com', 0);
INSERT INTO Voters ([Name], [Email], [HasVoted]) VALUES ('Valentina Ortiz', 'valentina@example.com', 0);

/*
-- Simulacion de votacion para pruebas

INSERT INTO Votes ([VoterId], [CandidateId]) VALUES (1, 2); -- Juan vota por Luis
INSERT INTO Votes ([VoterId], [CandidateId]) VALUES (2, 1); -- Laura vota por Ana
INSERT INTO Votes ([VoterId], [CandidateId]) VALUES (3, 3); -- Santiago vota por Marta
INSERT INTO Votes ([VoterId], [CandidateId]) VALUES (4, 2); -- Paula vota por Luis

-- Actualiza el campo HasVoted a 1 para esos votantes
UPDATE Voters SET HasVoted = 1 WHERE Id IN (1,2,3,4);

-- Actualiza el conteo de votos en Candidate
UPDATE Candidates SET Votes = Votes + 1 WHERE Id = 2;
UPDATE Candidates SET Votes = Votes + 1 WHERE Id = 1;
UPDATE Candidates SET Votes = Votes + 1 WHERE Id = 3;

*/

*/
