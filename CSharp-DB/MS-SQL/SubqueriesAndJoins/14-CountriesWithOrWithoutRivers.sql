    SELECT 
   TOP (5) [c].[CountryName],
           [r].[RiverName]
      FROM [CountriesRivers]
        AS [cr]
RIGHT JOIN [Countries]
        AS [c]
	    ON [cr].[CountryCode] = [c].[CountryCode]
	  JOIN [Continents]
	    AS [co]
	    ON [c].[ContinentCode] = [co].[ContinentCode]
 LEFT JOIN [Rivers]
        AS [r]
        ON [cr].[RiverId] = [r].[Id]
     WHERE [co].[ContinentName] = 'Africa'
  ORDER BY [c].[CountryName] ASC;