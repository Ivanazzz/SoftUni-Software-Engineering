  SELECT [p].[PeakName],
	     [r].[RiverName],
	     LOWER(CONCAT(SUBSTRING([p].[PeakName], 1, LEN([p].[PeakName]) - 1), [r].[RiverName]))
	  AS [Mix]
    FROM [Peaks]
      AS [p],
	     [Rivers]
	  AS [r]
   WHERE RIGHT(LOWER([p].[PeakName]), 1) = LEFT(LOWER([r].[RiverName]), 1)
ORDER BY [Mix];