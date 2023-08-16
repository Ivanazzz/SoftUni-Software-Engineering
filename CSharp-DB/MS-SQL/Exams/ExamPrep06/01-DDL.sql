CREATE DATABASE [WMS];

GO

CREATE TABLE [Clients] (
	[ClientId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Phone] CHAR(12) NOT NULL,
	CHECK(LEN([Phone]) = 12)
);

CREATE TABLE [Mechanics] (
	[MechanicId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
);

CREATE TABLE [Models] (
	[ModelId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE [Jobs] (
	[JobId] INT PRIMARY KEY IDENTITY,
	[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId]) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' NOT NULL,
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]) NOT  NULL,
	[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]),
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE,
	CHECK([Status] IN ('Pending', 'In Progress', 'Finished'))
);

CREATE TABLE [Orders] (
	[OrderId] INT PRIMARY KEY IDENTITY,
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[IssueDate] DATE,
	[Delivered] BIT DEFAULT 0 NOT NULL
);

CREATE TABLE [Vendors] (
	[VendorId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE [Parts] (
	[PartId] INT PRIMARY KEY IDENTITY,
	[SerialNumber] VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	[Price] DECIMAL(6, 2) NOT NULL,
	[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) NOT NULL,
	[StockQty] INT DEFAULT 0 NOT NULL,
	CHECK([Price] > 0),
	CHECK([StockQty] >= 0)
);

CREATE TABLE [OrderParts] (
	[OrderId] INT FOREIGN KEY REFERENCES [Orders]([OrderId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	[Quantity] INT DEFAULT 1 NOT NULL,
	PRIMARY KEY([OrderId], [PartId]),
	CHECK([Quantity] > 0)
);

CREATE TABLE [PartsNeeded] (
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	[Quantity] INT DEFAULT 1 NOT NULL,
	PRIMARY KEY([JobId], [PartId]),
	CHECK([Quantity] > 0)
);