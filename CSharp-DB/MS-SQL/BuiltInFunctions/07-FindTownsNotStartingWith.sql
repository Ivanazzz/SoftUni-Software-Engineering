-- Method 1
  SELECT [TownID],
	     [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC;

-- Method 2
  SELECT [TownID],
	     [Name]
    FROM [Towns]
   WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name] ASC;