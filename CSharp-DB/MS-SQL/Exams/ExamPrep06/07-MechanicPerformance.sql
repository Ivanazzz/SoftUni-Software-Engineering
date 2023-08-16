  SELECT [Mechanic],
		 AVG([DaysWorked])
	  AS [Average Days]
    FROM (
			  SELECT [m].[MechanicId],
					 CONCAT([m].[FirstName], ' ', [m].[LastName])
				  AS [Mechanic],
				     DATEDIFF(DAY, [j].[IssueDate], [j].[FinishDate])
				  AS [DaysWorked]
			    FROM [Mechanics]
				  AS [m]
			    JOIN [Jobs]
				  AS [j]
				  ON [m].[MechanicId] = [j].[MechanicId]
			   WHERE [j].[Status] = 'Finished'
	     )
	  AS [DaysWorkedSubquery]
GROUP BY [Mechanic], [MechanicId]
ORDER BY [MechanicId] ASC;