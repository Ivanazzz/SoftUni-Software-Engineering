-- Method 1
  SELECT [CountryCode],
	     COUNT([MountainID])
	  AS [MountainRanges]
    FROM [MountainsCountries]
   WHERE [CountryCode] IN (
							   SELECT [CountryCode]
                                 FROM [Countries]
                                WHERE [CountryName] IN ('United States', 'Russia', 'Bulgaria')
						  )
GROUP BY [CountryCode];

-- Method 2
  SELECT [mc].[CountryCode],
	     COUNT([mc].[CountryCode])
	  AS [MountainRanges]
    FROM [MountainsCountries]
      AS [mc]
    JOIN [Countries]
      AS [c]
	  ON [mc].[CountryCode] = [c].[CountryCode]
    JOIN [Mountains]
      AS [m]
	  ON [mc].[MountainId] = [m].[Id]
   WHERE [c].[CountryName] IN ('United States', 'Russia', 'Bulgaria')
GROUP BY [mc].[CountryCode];