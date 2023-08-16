  SELECT [Name]
      AS [Game],
	     CASE
		    WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
			ELSE 'Evening'
		 END
	  AS [Part of the day],
	     CASE
		    WHEN [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] >= 4 AND [Duration] <= 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			ELSE 'Extra Long'
		 END
	  AS [Duration]
    FROM [Games]
	  AS [g]
ORDER BY [Game] ASC,
         [Duration] ASC,
		 [Part of the day] ASC;