  SELECT 
 TOP (5) [e].[EmployeeID],
	     [e].[FirstName],
	     [p].[Name]
	  as [ProjectName]
    FROM [EmployeesProjects]
      AS [ep]
    JOIN [Employees]
      AS [e]
	  ON [ep].EmployeeID = [e].[EmployeeID]
    JOIN [Projects]
      AS [p]
	  ON [ep].[ProjectID] = [p].[ProjectID]
   WHERE [p].[StartDate] > '08-13-2002' AND [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID] ASC;