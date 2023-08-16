  SELECT CONCAT([c].[FirstName], ' ', [c].[LastName])
	  AS [FullName],
		 [c].[Email],
		 MAX([b].[Rating])
	  AS [Rating]
	FROM [Creators]
	  AS [c]
	JOIN [CreatorsBoardgames]
	  AS [cb]
	  ON [c].[Id] = [cb].[CreatorId]
	JOIN [Boardgames]
	  AS [b]
	  ON [b].[Id] = [cb].[BoardgameId]
   WHERE [c].[Email] LIKE ('%.com')
GROUP BY CONCAT([c].[FirstName], ' ', [c].[LastName]), [c].[Email]
ORDER BY [FullName] ASC;