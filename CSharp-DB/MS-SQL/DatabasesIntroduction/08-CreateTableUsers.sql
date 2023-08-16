CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH ([ProfilePicture]) <= 900000),
	LastLoginTime DATETIME2,
	IsDeleted BIT
);

INSERT INTO Users
VALUES
	('Peter', '12332', null, '10-20-2022', 0),
	('Ivan', '66229', null, '12-11-2022', 1),
	('Ivaylo', '12345', null, '02-16-2021', 0),
	('David', '78903', null, '06-27-2022', 0),
	('Kiril', '17176', null, '09-18-2020', 1);