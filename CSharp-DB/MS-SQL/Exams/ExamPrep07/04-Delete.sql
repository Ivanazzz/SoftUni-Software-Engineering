SELECT [Id]
  FROM [Repositories]
 WHERE [Name] = 'Softuni-Teamwork';

DELETE
  FROM [RepositoriesContributors]
 WHERE [RepositoryId] = (
							SELECT [Id]
							  FROM [Repositories]
							 WHERE [Name] = 'Softuni-Teamwork'
						);

SELECT [Id]
  FROM [Issues]
 WHERE [RepositoryId] = (
							SELECT [Id]
							  FROM [Repositories]
							 WHERE [Name] = 'Softuni-Teamwork'
						);

DELETE
  FROM [Commits]
 WHERE [IssueId] IN (
						SELECT [Id]
						  FROM [Issues]
						 WHERE [RepositoryId] = (
													SELECT [Id]
													  FROM [Repositories]
													 WHERE [Name] = 'Softuni-Teamwork'
						)
					);

DELETE
  FROM [Issues]
 WHERE [RepositoryId] = (
							SELECT [Id]
							  FROM [Repositories]
							 WHERE [Name] = 'Softuni-Teamwork'
						);