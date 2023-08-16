-- PROBLEM 01: Initial Setup
CREATE DATABASE [MinionsDB];

GO

CREATE TABLE [Countries] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100)
);

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100),
	[CountryCode] INT FOREIGN KEY REFERENCES [Countries]([Id])
);

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200),
	[Age] INT,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
);

CREATE TABLE [EvilnessFactors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100)
);

CREATE TABLE [Villains] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200),
	[EvilnessFactorId] INT FOREIGN KEY REFERENCES [EvilnessFactors]([Id])
);

CREATE TABLE [MinionsVillains] (
	[MinionId] INT FOREIGN KEY REFERENCES [Minions]([Id]),
	[VillainId] INT FOREIGN KEY REFERENCES [Villains]([Id]),
	PRIMARY KEY ([MinionId], [VillainId])
);


-- PROBLEM 02: Villain Names
  SELECT [v].[Name],
		 COUNT(*)
	  AS [MinionsCount]
	FROM [Villains]
	  AS [v]
	JOIN [MinionsVillains]
	  AS [mv]
	  ON [v].[Id] = [mv].[VillainId]
	JOIN [Minions]
	  AS [m]
	  ON [m].[Id] = [mv].[MinionId]
GROUP BY [v].[Name]
  HAVING COUNT(*) > 3
ORDER BY COUNT(*) DESC;


-- PROBLEM 03: Minion Names
SELECT [Name]
  FROM [Villains]
 WHERE [Id] = @Id;

  SELECT ROW_NUMBER() OVER (ORDER BY [m].[Name]) 
	  AS RowNum,
	     [m].[Name],
	     [m].[Age]
	FROM [Villains]
      AS [v]
	JOIN [MinionsVillains]
	  AS [mv]
	  ON [v].[Id] = [mv].[VillainId]
	JOIN [Minions]
      AS [m]
	  ON [m].[Id] = [mv].[MinionId]
   WHERE [v].[Id] = @Id
ORDER BY [m].[Name] ASC;


-- PROBLEM 04: Add Minion
SELECT [Id] 
  FROM [Towns] 
 WHERE [Name] = @townName;

INSERT INTO [Towns]
			([Name]) 
	 VALUES (@townName);

SELECT [Id] 
  FROM [Villains] 
 WHERE [Name] = @Name;

INSERT INTO [Villains]
			([Name], [EvilnessFactorId])
	 VALUES (@villainName, 4);

INSERT INTO [Minions]
			([Name], [Age], [TownId]) 
	 VALUES (@name, @age, @townId);

SELECT [Id] 
  FROM [Minions] 
 WHERE [Name] = @Name;

INSERT INTO [MinionsVillains]
			([MinionId], [VillainId])
	 VALUES (@minionId, @villainId);


-- PROBLEM 05: Change Town Names Casing
SELECT [t].[Name]
  FROM [Countries]
	AS [c]
  JOIN [Towns]
	AS [t]
	ON [c].[Id] = [t].[CountryCode]
 WHERE [c].[Name] = @countryName;

UPDATE [Towns]
   SET [Name] = UPPER([Name])
 WHERE [CountryCode] = (
							SELECT DISTINCT [c].[Id]
									   FROM [Countries]
										 AS [c]
									   JOIN [Towns]
										 AS [t]
										 ON [c].[Id] = [t].[CountryCode]
									  WHERE [c].[Name] = @countryName
					   );


-- Problem 06: Remove Villain
SELECT [Name] 
  FROM [Villains] 
 WHERE [Id] = @villainId;

DELETE
  FROM [MinionsVillains]
 WHERE [VillainId] = 2;

DELETE
  FROM [Villains]
 WHERE [Id] = 2;

SELECT * FROM [MinionsVillains] WHERE [VillainId] = 1;
SELECT * FROM [Villains] WHERE [Id] = 1;


-- Problem 07: Print All Minion Names
SELECT [Name]
  FROM [Minions];


-- Problem 08: Increase Minion Age
UPDATE [Minions]
   SET [Age] += 1,
	   [Name] = LOWER([Name])
 WHERE [Id] = @Id;

SELECT [Name],
	   [Age]
  FROM [Minions];


-- Problem 09: Increase Age Stored Procedure
CREATE PROC [usp_GetOlder] @Id INT
		 AS
	  BEGIN
			UPDATE [Minions]
			   SET [Age] += 1
			 WHERE [Id] = @Id;
	    END;

SELECT [Name],
	   [Age]
  FROM [Minions]
 WHERE [Id] = @Id;