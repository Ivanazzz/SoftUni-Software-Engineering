   SELECT 
  TOP (5) [r].[Id],
		  [r].[Name],
		  COUNT([c].[Id])
	   AS [Commits]
     FROM [Repositories]
       AS [r]
LEFT JOIN [Commits]
	   AS [c]
	   ON [c].[RepositoryId] = [r].[Id]
LEFT JOIN [RepositoriesContributors]
	   AS [rc]
	   ON [rc].[RepositoryId] = [r].[Id]
 GROUP BY [r].[Id],
		  [r].[Name]
 ORDER BY [Commits] DESC,
		  [r].[Id] ASC,
		  [r].[Name] ASC;