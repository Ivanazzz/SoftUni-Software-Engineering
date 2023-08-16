CREATE PROC [usp_GetEmployeesFromTown] @townName VARCHAR(50)
		 AS
	  BEGIN
			SELECT [FirstName]
				AS [First Name],
				   [LastName]
				AS [Last Name]
			  FROM [Employees]
			    AS [e]
			  JOIN [Addresses]
			    AS [a]
				ON [a].[AddressID] = [e].[AddressID]
			  JOIN [Towns]
			    AS [t]
				ON [t].[TownID] = [a].[TownID]
			 WHERE [t].[Name] = @townName
	    END;

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia';