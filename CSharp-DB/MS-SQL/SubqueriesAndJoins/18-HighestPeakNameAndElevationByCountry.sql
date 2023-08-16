  SELECT 
 TOP (5) [CountryName]
      AS [Country],
	     ISNULL([PeakName], '(no highest peak)')
	  AS [Highest Peak Name],
	     ISNULL([Elevation], 0)
	  AS [Highest Peak Elevation],
		 ISNULL([MountainRange], '(no mountain)')
	  AS [Mountain]
    FROM (
		        SELECT [c].[CountryName],
		               [p].[PeakName],
		               [p].[Elevation],
		               [m].[MountainRange],
		               DENSE_RANK() OVER (PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC)
	                AS [PeakRank]
                  FROM [Countries]
                    AS [c]
             LEFT JOIN [MountainsCountries]
                    AS [mc]
                    ON [c].[CountryCode] = [mc].[CountryCode]
             LEFT JOIN [Mountains]
	                AS [m]
	                ON [mc].[MountainId] = [m].[Id]
             LEFT JOIN [Peaks]
	                AS [p]
	                ON [p].[MountainId] = [m].[Id]
	     )
	  AS [PeakRankingSubquery]
   WHERE [PeakRank] = 1
ORDER BY [Country] ASC,
		 [Highest Peak Name] ASC;