  SELECT [c].[CountryCode],
		 [m].[MountainRange],
		 [p].[PeakName],
		 [p].[Elevation]
    FROM [MountainsCountries]
      AS [mc]
	JOIN [Countries]
	  AS [c]
	  ON [mc].[CountryCode] = [c].[CountryCode]
    JOIN [Mountains]
      AS [m]
	  ON [mc].[MountainId] = [m].[Id]
    JOIN [Peaks]
      AS [p]
	  ON [p].[MountainId] = [m].[Id]
   WHERE [c].[CountryName] = 'Bulgaria' AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC;