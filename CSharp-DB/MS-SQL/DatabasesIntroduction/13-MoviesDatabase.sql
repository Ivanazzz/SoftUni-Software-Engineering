CREATE DATABASE Movies;

USE Movies;

CREATE TABLE Directors (
	Id INT PRIMARY KEY,
	DirectorName VARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Directors
	(Id, DirectorName)
VALUES
	(1, 'Steven King'),
	(2, 'Edgar Allan Poe'),
	(3, 'Agatha Christie'),
	(4, 'Hristo Botev'),
	(5, 'Ivan Vazov');

CREATE TABLE Genres (
	Id INT PRIMARY KEY,
	GenreName VARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Genres
	(Id, GenreName)
VALUES
	(1, 'Horror'),
	(2, 'Romance'),
	(3, 'Mystery'),
	(4, 'Adventure'),
	(5, 'Fiction');

CREATE TABLE Categories (
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Categories
	(Id, CategoryName)
VALUES
	(1, 'C'),
	(2, 'B'),
	(3, 'C'),
	(4, 'A'),
	(5, 'B');

CREATE TABLE Movies (
	Id INT PRIMARY KEY,
	Title VARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] DECIMAL(3, 2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
);

INSERT INTO Movies
	(Id, Title, DirectorId, CopyrightYear, GenreId, CategoryId)
VALUES
	(1, 'Pirates of the Caribbean', 2, '02-13-2003', 4, 4),
	(2, 'Mr Bean', 1, '05-03-1999', 5, 1),
	(3, 'Titanic', 3, '11-11-2001', 2, 3),
	(4, 'Sherlock Holmes', 4, '12-17-2006', 3, 5),
	(5, 'Volcano', 5, '10-28-2010', 1, 2);