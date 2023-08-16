  SELECT DISTINCT SUBSTRING([t].[Name], CHARINDEX(' ', [t].[Name]) + 1, LEN([t].[Name]))
	  AS [LastName],
		 [t].[Nationality],
		 [t].[Age],
		 [t].[PhoneNumber]
	FROM [Tourists]
	  AS [t]
	JOIN [SitesTourists]
	  AS [st]
	  ON [t].[Id] = [st].[TouristId]
	JOIN [Sites]
	  AS [s]
	  ON [s].[Id] = [st].[SiteId]
	JOIN [Categories]
	  AS [c]
	  ON [c].[Id] = [s].[CategoryId]
   WHERE [c].[Name] = 'History and archaeology'
ORDER BY [LastName];