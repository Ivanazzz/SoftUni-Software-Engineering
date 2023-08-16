-- Method 1
   SELECT [c].[Id],
	      CONCAT([c].[FirstName], ' ', [c].[LastName])
	   AS [ClientName],
	      [c].[Email]
	 FROM [Clients]
       AS [c]
LEFT JOIN [ClientsCigars]
	   AS [cc]
	   ON [cc].[ClientId] = [c].[Id]
	WHERE [cc].[ClientId] IS NULL
 ORDER BY [ClientName] ASC;

-- Method 2
  SELECT [Id],
	     CONCAT([FirstName], ' ', [LastName])
	  AS [ClientName],
	     [Email]
    FROM [Clients]
	  AS [c]
   WHERE [Id] NOT IN (
						  SELECT [ClientId]
						    FROM [ClientsCigars]
				   )
ORDER BY [ClientName] ASC;