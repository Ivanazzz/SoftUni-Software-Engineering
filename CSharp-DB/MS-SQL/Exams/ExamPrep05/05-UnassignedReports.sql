  SELECT [r].[Description],
		 FORMAT([OpenDate], 'dd-MM-yyyy')
	  AS [OpenDate]
	FROM [Reports]
	  AS [r]
   WHERE [r].[EmployeeId] IS NULL
ORDER BY [r].[OpenDate] ASC,
		 [r].[Description] ASC;