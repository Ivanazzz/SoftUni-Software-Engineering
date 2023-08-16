SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10) AND YEAR([HireDate]) >= 1995 AND YEAR([HireDate]) <= 2005;