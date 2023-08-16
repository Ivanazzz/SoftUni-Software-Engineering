CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK (LEN([Picture]) <= 2000000),
	Height DECIMAL(2, 2),
	[Weight] DECIMAL(2, 2),
	Gender VARCHAR(1) NOT NULL CHECK ([GENDER] = 'm' OR [GENDER] = 'f'),
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
);

INSERT INTO People
	([Name], Gender, Birthdate)
VALUES
	('Ivan Ivanov', 'm', '04-15-2002'),
	('Peter Petrov', 'm', '09-09-2004'),
	('Sara Popova', 'f', '02-04-2003'),
	('Eli Dimitrova', 'f', '11-10-2002'),
	('Ivaylo Mihaylov', 'm', '03-27-2003');