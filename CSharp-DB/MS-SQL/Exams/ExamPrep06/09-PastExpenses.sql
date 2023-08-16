  SELECT [j].[JobId],
	     SUM([pn].[Quantity] * [p].[Price])
	  AS [Total]
	FROM [PartsNeeded]
      AS [pn]
	JOIN [Jobs]
      AS [j]
	  ON [j].[JobId] = [pn].[JobId]
	JOIN [Parts]
      AS [p]
	  ON [p].[PartId] = [pn].[PartId]
   WHERE [j].[Status] = 'Finished'
GROUP BY [j].[JobId]
ORDER BY [Total] DESC,
		 [JobId] ASC;