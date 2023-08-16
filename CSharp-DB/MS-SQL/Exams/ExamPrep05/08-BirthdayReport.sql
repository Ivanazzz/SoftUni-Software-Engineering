  SELECT [u].[Username],
		 [c].[Name]
	  AS [CategoryName]
	FROM [Users]
	  AS [u]
	JOIN [Reports]
	  AS [r]
	  ON [u].[Id] = [r].[UserId]
	JOIN [Categories]
	  AS [c]
	  ON [c].[Id] = [r].[CategoryId]
   WHERE DAY([r].[OpenDate]) = DAY([u].[Birthdate])
	 AND MONTH([r].[OpenDate]) = MONTH([u].[Birthdate])
ORDER BY [u].[Username] ASC,
		 [c].[Name] ASC;