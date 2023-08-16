CREATE DATABASE CarRental;

USE CarRental;

CREATE TABLE Categories (
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(100) NOT NULL,
	DailyRate SMALLINT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate SMALLINT,	
);

INSERT INTO Categories
	(Id, CategoryName)
VALUES
	(1, 'fast'),
	(2, 'average'),
	(3, 'slow');

CREATE TABLE Cars (
	Id INT PRIMARY KEY,
	PlateNumber NCHAR(8) NOT NULL,
	Manufacturer VARCHAR(100) NOT NULL,
	Model VARCHAR(100) NOT NULL,
	CarYear DATETIME2 NOT NULL,
	CategoryId INT NOT NULL,
	Doors BIT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(50) NOT NULL,
	Available BIT NOT NULL
);

INSERT INTO Cars
	(Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
	(1, 'PK8912SZ', 'Audi', 'Q7', '12-12-2022', 1, 4, 'new', 1),
	(2, 'AB7777MK', 'BMW', 'X5', '04-11-2007', 3, 4, 'old', 1),
	(3, 'KL9812PP', 'Mercedes', 'AMG', '04-28-2010', 2, 4, 'new', 0);

CREATE TABLE Employees (
	Id INT PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Title VARCHAR(50),
	Notes VARCHAR(Max)
);

INSERT INTO Employees
	(Id, FirstName, LastName)
VALUES
	(1, 'Ivan', 'Ivanov'),
	(2, 'Peter', 'Borisov'),
	(3, 'Ivaylo', 'Petrov');

CREATE TABLE Customers (
	Id INT PRIMARY KEY,
	DriverLicenceNumber CHAR(10) NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	[Address] VARCHAR(50),
	City VARCHAR(50) NOT NULL,
	ZIPCode INT,
	Notes VARCHAR(Max)
);

INSERT INTO Customers
	(Id, DriverLicenceNumber, FullName, City)
VALUES
	(1, '1234567892', 'Sara Popova', 'Sofia'),
	(2, '5477821693', 'Kati Pavlova', 'Varna'),
	(3, '8795124778', 'Eli Dimitrova', 'Sofia');

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel TINYINT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays INT,
	RateApplied SMALLINT,
	TaxRate SMALLINT,
	OrderStatus BIT NOT NULL,
	Notes VARCHAR(Max)
);

INSERT INTO RentalOrders
	(Id, EmployeeId, CustomerId, CarId, OrderStatus)
VALUES
	(1, 2, 1, 1, 1),
	(2, 1, 3, 3, 0),
	(3, 3, 2, 2, 1);