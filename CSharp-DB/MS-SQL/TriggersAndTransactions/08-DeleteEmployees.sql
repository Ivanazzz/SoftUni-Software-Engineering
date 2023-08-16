CREATE TABLE [Deleted_Employees]
(
	[EmployeeId] INT PRIMARY KEY IDENTITY, 
	[FirstName] VARCHAR(50) NOT NULL, 
	[LastName] VARCHAR(50) NOT NULL, 
	[MiddleName] VARCHAR(50) NOT NULL, 
	[JobTitle] VARCHAR(50) NOT NULL, 
	[DepartmentId] INT NOT NULL, 
	[Salary] DECIMAL(18, 2) NOT NULL
);

GO

CREATE TRIGGER [tr_AddEntityToDeletedEmployeesTable]
			ON [Employees] 
	FOR DELETE
			AS
   INSERT INTO [Deleted_Employees]	
		SELECT [FirstName],
			   [LastName],
			   [MiddleName],
			   [JobTitle],
			   [DepartmentID],
			   [Salary]
		  FROM deleted;