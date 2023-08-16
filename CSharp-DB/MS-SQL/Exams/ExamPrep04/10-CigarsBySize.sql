  SELECT [c].[LastName],
		 AVG([s].[Length])
	  AS [CigarLength],
		 CEILING(AVG([s].[RingRange]))
	  AS [CigarRingRange]
	FROM [ClientsCigars]
      AS [cc]
	JOIN [Clients]
      AS [c]
	  ON [c].[Id] = [cc].[ClientId]
	JOIN [Cigars]
      AS [cg]
	  ON [cg].[Id] = [cc].[CigarId]
	JOIN [Sizes]
      AS [s]
	  ON [s].[Id] = [cg].[SizeId]
GROUP BY [c].[LastName]
ORDER BY [CigarLength] DESC;