   SELECT CASE
			 WHEN
			 COALESCE([e].[FirstName], [e].[LastName]) IS NOT NULL
			 THEN CONCAT([e].[FirstName], ' ', [e].[LastName])
			 ELSE 'None'
		  END
	   AS [Employee],
		  ISNULL([d].[Name], 'None')
	   AS [Departmnet],
		  ISNULL([c].[Name], 'None')
	   AS [Category],
		  ISNULL([r].[Description], 'None'),
		  ISNULL(FORMAT([r].[OpenDate], 'dd.MM.yyyy'), 'None')
	   AS [OpenDate],
		  ISNULL([s].[Label], 'None')
	   AS [Status],
		  ISNULL([u].[Name], 'None')
	   AS [User]
	 FROM [Reports]
	   AS [r]
LEFT JOIN [Users]
	   AS [u]
	   ON [u].[Id] = [r].[UserId]
LEFT JOIN [Employees]
	   AS [e]
	   ON [e].[Id] = [r].[EmployeeId]
LEFT JOIN [Departments]
	   AS [d]
	   ON [d].[Id] = [e].[DepartmentId]
LEFT JOIN [Categories]
	   AS [c]
	   ON [c].[Id] = [r].[CategoryId]
LEFT JOIN [Status]
	   AS [s]
	   ON [s].[Id] = [r].[StatusId]
 ORDER BY [e].[FirstName] DESC,
		  [e].[LastName] DESC,
		  [d].[Name] ASC,
		  [c].[Name] ASC,
		  [r].[Description] ASC,
		  [r].[OpenDate] ASC,
		  [s].[Label] ASC,
		  [u].[Name] ASC;