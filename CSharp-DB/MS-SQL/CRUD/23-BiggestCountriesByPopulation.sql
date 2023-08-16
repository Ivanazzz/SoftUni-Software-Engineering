USE Geography
GO

  SELECT
     TOP (30) [CountryName],
	  	      [Population]
    FROM [Countries]
   WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC,
         [CountryName] ASC;


-- ADVANCED SOLUTION

  SELECT
     TOP (30) [CountryName],
	  	      [Population]
    FROM [Countries]
   WHERE [ContinentCode] =
						    (
						         SELECT [ContinentCode]
							       FROM [Continents]
							      WHERE [ContinentName] = 'Europe'
						    )
ORDER BY [Population] DESC,
         [CountryName] ASC;