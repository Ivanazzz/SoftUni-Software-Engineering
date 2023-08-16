namespace VillainNames
{
    public static class SqlQueries
    {
        public const string GetAllVillainsAndCountOfTheirMinions =
            @"  SELECT [v].[Name],
					   COUNT(*)
					AS [MinionsCount]
				  FROM [Villains]
					AS [v]
				  JOIN [MinionsVillains]
					AS [mv]
					ON [v].[Id] = [mv].[VillainId]
				  JOIN [Minions]
					AS [m]
					ON [m].[Id] = [mv].[MinionId]
			  GROUP BY [v].[Name]
				HAVING COUNT(*) > 3
			  ORDER BY COUNT(*) DESC;";
    }
}
