  SELECT DISTINCT CONCAT([c].[FirstName], ' ', [c].[LastName])
	  AS [FullName],
	     [a].[Country],
	     [a].[ZIP],
	     CONCAT('$', (
						  SELECT MAX([PriceForSingleCigar])
						    FROM [Cigars] 
						      AS [cg] 
						    JOIN [ClientsCigars] 
						      AS [cc] 
							  ON [cg].[Id] = [cc].[CigarId] AND [c].[Id] = [cc].[ClientId]))
	  AS [CigarPrice]
	FROM [Clients]
      AS [c]
	JOIN [Addresses]
      AS [a]
	  ON [a].[Id] = [c].[AddressId]
   WHERE ISNUMERIC([a].[ZIP]) = 1
ORDER BY 1 ASC;