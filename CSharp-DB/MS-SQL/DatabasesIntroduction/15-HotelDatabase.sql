CREATE DATABASE Hotel;

USE Hotel;

CREATE TABLE Employees (
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Employees
	(Id, FirstName, LastName, Title)
VALUES
	(1, 'Ivan', 'Ivanov', 'Manager'),
	(2, 'Peter', 'Petrov', 'IT'),
	(3, 'Ivaylo', 'Kolev', 'HR');

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName NVARCHAR(100) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Customers
	(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
	(1, 'Ivana', 'Pavlova', '0877122133', 'I', '0877122144'),
	(2, 'Sara', 'Popova', '0877752178', 'S', '0877752197'),
	(3, 'Eli', 'Dimitrova', '0877542111', 'E', '0877542122');

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO RoomStatus
	(RoomStatus)
VALUES
	('A'),
	('A'),
	('B');

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO RoomTypes
	(RoomType)
VALUES
	('Single'),
	('Double'),
	('Triple');

CREATE TABLE BedTypes (
	BedType NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO BedTypes
	(BedType)
VALUES
	('Twin'),
	('Full'),
	('King');

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(10) NOT NULL,
	BedType NVARCHAR(10) NOT NULL,
	Rate TINYINT,
	RoomStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Rooms
	(RoomNumber, RoomType, BedType, RoomStatus)
VALUES
	(1, 'Triple', 'Full', 'B'),
	(2, 'Single', 'King', 'A'),
	(3, 'Double', 'Twin', 'B');

CREATE TABLE Payments (
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays TINYINT NOT NULL,
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount DECIMAL(15, 2) NOT NULL,
	PaymentTotal DECIMAL(15, 2) NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Payments
	(Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES
	(1, 5, '06-12-2022', 21, '06-14-2022', '06-20-2022', 6, 105.67, 2, 12.36, 118.03),
	(2, 7, '03-02-2022', 14, '03-04-2022', '03-05-2022', 1, 22.40, 2, 5.89, 28.29),
	(3, 6, '08-23-2022', 18, '08-23-2022', '08-26-2022', 3, 59.00, 2, 34.00, 93.00);

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15, 2),
	Notes NVARCHAR(MAX)
);

INSERT INTO Occupancies
	(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber)
VALUES
	(1, 14, '06-12-2022', 21, 4),
	(2, 5, '03-02-2022', 14, 1),
	(3, 12, '08-23-2022', 18, 3);