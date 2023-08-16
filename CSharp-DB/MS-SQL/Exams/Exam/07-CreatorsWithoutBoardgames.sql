   SELECT [Id],
		  CONCAT([c].[FirstName], ' ', [c].[LastName])
	   AS [CreatorName],
		  [C].[Email]
	 FROM [Creators]
	   AS [c]
LEFT JOIN [CreatorsBoardgames]
	   AS [cb]
	   ON [c].[Id] = [cb].[CreatorId]
    WHERE [cb].[CreatorId] IS NULL
 ORDER BY [CreatorName];