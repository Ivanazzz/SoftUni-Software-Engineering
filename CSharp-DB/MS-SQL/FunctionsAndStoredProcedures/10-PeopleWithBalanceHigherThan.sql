CREATE PROC [usp_GetHoldersWithBalanceHigherThan] @minBalance MONEY
		 AS
	  BEGIN
			  SELECT [ah].[FirstName]
				  AS [First Name],
				     [ah].[LastName]
				  AS [Last Name]
			    FROM [AccountHolders]
			      AS [ah]
			    JOIN [Accounts]
			      AS [a]
				  ON [ah].[Id] = [a].[AccountHolderId]
			GROUP BY [ah].[Id], [ah].[FirstName], [ah].[LastName]
			  HAVING SUM([a].[Balance]) > @minBalance
			ORDER BY [ah].[FirstName] ASC,
					 [ah].[LastName] ASC

	    END;

EXEC [dbo].[usp_GetHoldersWithBalanceHigherThan] 10000;