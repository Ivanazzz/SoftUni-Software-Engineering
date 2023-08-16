  SELECT CONCAT([o].[Name], '-', [a].[Name])
	  AS [OwnersAnimals],
	     [o].[PhoneNumber],
	     [c].[Id]
	  AS [CageId]
	FROM [AnimalsCages]
      AS [ac]
	JOIN [Cages]
      AS [c]
	  ON [c].[Id] = [ac].[CageId]
	JOIN [Animals]
      AS [a]
	  ON [a].[Id] = [ac].[AnimalId]
	JOIN [Owners]
	  AS [o]
	  ON [o].[Id] = [a].[OwnerId]
	JOIN [AnimalTypes]
      AS [at]
	  ON [at].[Id] = [a].[AnimalTypeId]
   WHERE [at].[AnimalType] = 'mammals'
ORDER BY [o].[Name] ASC,
		 [a].[Name] DESC;