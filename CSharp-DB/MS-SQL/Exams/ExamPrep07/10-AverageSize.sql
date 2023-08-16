   SELECT [u].[Username],
		  AVG([f].[Size])
	   AS [Size]
     FROM [Commits]
	   AS [c]
LEFT JOIN [Users]
	   AS [u]
	   ON [u].[Id] = [c].[ContributorId]
	 JOIN [Files]
	   AS [f]
	   ON [c].[Id] = [f].[CommitId]
 GROUP BY [u].[Username]
 ORDER BY [Size] DESC,
		  [Username] ASC;