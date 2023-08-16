  SELECT [a].[Name],
	     YEAR([a].[BirthDate])
	  AS [BirthYear],
	     [at].[AnimalType]
	FROM [Animals]
      AS [a]
	JOIN [AnimalTypes]
      AS [at]
	  ON [at].[Id] = [a].[AnimalTypeId]
   WHERE [a].[OwnerId] IS NULL 
		 AND [at].[AnimalType] <> 'Birds'
		 AND DATEDIFF(YEAR, [BirthDate], '01/01/2022') < 5
ORDER BY [a].[Name] ASC;