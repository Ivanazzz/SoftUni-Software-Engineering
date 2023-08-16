CREATE PROC [usp_EmployeesBySalaryLevel] @levelOfSalary VARCHAR(8)
		 AS
	  BEGIN
			SELECT [FirstName]
				AS [First Name],
				   [LastName]
				AS [Last Name]
			  FROM [Employees]
			 WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @levelOfSalary
		END;

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High';