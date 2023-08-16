CREATE PROC [usp_AnimalsWithOwnersOrNot] @AnimalName VARCHAR(30)
		 AS
	  BEGIN
			   SELECT [a].[Name]
				   AS [Name],
					  CASE
					     WHEN [o].[Name] IS NULL
					     THEN 'For adoption'
					     ELSE [o].[Name]
					  END
				   AS [OwnersName]
				 FROM [Animals]
				   AS [a]
			LEFT JOIN [Owners]
				   AS [o]
				   ON [o].[Id] = [a].[OwnerId]
				WHERE [a].[Name] = @AnimalName
	    END;

EXEC [usp_AnimalsWithOwnersOrNot] 'Pumpkinseed Sunfish';

EXEC [usp_AnimalsWithOwnersOrNot] 'Hippo';

EXEC [usp_AnimalsWithOwnersOrNot] 'Brown bear';