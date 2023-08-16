-- Method 1
  SELECT [TownID],
	     [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC;

-- Method 2
  SELECT [TownID],
	     [Name]
    FROM [Towns]
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC;
