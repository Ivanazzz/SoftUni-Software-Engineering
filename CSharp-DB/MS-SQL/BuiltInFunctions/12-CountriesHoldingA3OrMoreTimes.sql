-- Method 1
  SELECT [CountryName]
      AS [Country Name],
	     [ISOCode]
	  AS [ISO Code]
    FROM [Countries]
   WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode] ASC;

-- Method 2
  SELECT [CountryName]
      AS [Country Name],
	     [ISOCode]
	  AS [ISO Code]
    FROM [Countries]
   WHERE LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]), 'a', '')) >= 3
ORDER BY [IsoCode] ASC;