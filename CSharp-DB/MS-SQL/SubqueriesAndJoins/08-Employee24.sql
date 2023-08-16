SELECT [e].[EmployeeID],
	   [e].[FirstName],
	   CASE
		  WHEN YEAR([p].[StartDate]) >= 2005 THEN NULL
		  ELSE [p].[Name]
	   END
	AS [ProjectName]
  FROM [EmployeesProjects]
    AS [ep]
  JOIN [Projects]
    AS [p]
	ON [ep].[ProjectID] = [p].[ProjectID]
  JOIN [Employees]
    AS [e]
	ON [e].[EmployeeID] = [ep].[EmployeeID]
 WHERE [ep].[EmployeeID] = 24;