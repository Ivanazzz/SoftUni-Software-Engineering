  SELECT [s].[Name]
	  AS [Site],
		 [l].[Name]
	  AS [Location],
		 [s].[Establishment],
		 [c].[Name]
	  AS [Category]
	FROM [Sites]
	  AS [s]
	JOIN [Locations]
	  AS [l]
	  ON [l].[Id] = [s].[LocationId]
	JOIN [Categories]
	  AS [c]
	  ON [c].[Id] = [s].[CategoryId]
ORDER BY [c].[Name] DESC,
		 [l].[Name] ASC,
		 [s].[Name] ASC;