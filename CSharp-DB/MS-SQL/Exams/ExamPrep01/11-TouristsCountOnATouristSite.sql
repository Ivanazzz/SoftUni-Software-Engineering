CREATE FUNCTION [udf_GetTouristsCountOnATouristSite] (@Site VARCHAR(100))
	RETURNS INT
			 AS
		  BEGIN
				DECLARE @count INT = (
											SELECT COUNT(*)
											  FROM [Tourists]
											    AS [t]
											  JOIN [SitesTourists]
											    AS [st]
												ON [t].[Id] = [st].[TouristId]
											  JOIN [Sites]
											    AS [s]
												ON [s].[Id] = [st].[SiteId]
											 WHERE [s].[Name] = @Site
									 );

				RETURN @count;
		    END;

SELECT [dbo].[udf_GetTouristsCountOnATouristSite] ('Regional History Museum – Vratsa');

SELECT [dbo].[udf_GetTouristsCountOnATouristSite] ('Samuil’s Fortress');

SELECT [dbo].[udf_GetTouristsCountOnATouristSite] ('Gorge of Erma River');