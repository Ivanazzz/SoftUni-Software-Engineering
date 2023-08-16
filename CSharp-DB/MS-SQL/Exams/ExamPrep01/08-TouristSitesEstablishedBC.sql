  SELECT [s].[Name]
	  AS [Site],
		 [l].[Name]
	  AS [Location],
		 [l].[Municipality],
		 [l].[Province],
		 [s].[Establishment]
	FROM [Sites]
      AS [s]
	JOIN [Locations]
      AS [l]
	  ON [l].[Id] = [s].[LocationId]
   WHERE SUBSTRING([l].[Name], 1, 1) NOT IN ('B', 'M', 'D')
	 AND [s].[Establishment] LIKE '% BC'
ORDER BY [s].[Name] ASC;	