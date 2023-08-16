  SELECT 
 TOP (5) [b].[Name],
		 [b].[Rating],
		 [c].[Name]
	  AS [CategoryName]
	FROM [Boardgames]
	  AS [b]
	JOIN [PlayersRanges]
	  AS [pr]
	  ON [pr].[Id] = [b].[PlayersRangeId]
	JOIN [Categories]
	  AS [c]
	  ON [c].[Id] = [b].[CategoryId]
   WHERE ([b].[Rating] > 7.00 AND [b].[Name] LIKE ('%a%'))
	  OR ([b].[Rating] > 7.50 AND [pr].[PlayersMin] >= 2 AND [pr].[PlayersMax] <= 5)
ORDER BY [b].[Name] ASC,
		 [b].[Rating] DESC;