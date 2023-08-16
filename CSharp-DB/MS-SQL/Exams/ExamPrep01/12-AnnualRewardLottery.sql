CREATE PROC [usp_AnnualRewardLottery] @TouristName VARCHAR(50)
		 AS
	  BEGIN
			IF (
					SELECT COUNT([s].[Id]) 
					  FROM [Sites] 
					    AS [s]
					  JOIN [SitesTourists] 
					    AS [st] 
						ON [s].[Id] = [st].[SiteId]
					  JOIN [Tourists] 
					    AS [t] 
						ON [t].[Id] = [st].[TouristId]
					 WHERE [t].[Name] = @TouristName) 
				>= 100
			BEGIN 
				UPDATE [Tourists]
				   SET [Reward] = 'Gold badge'
				 WHERE [Name] = @TouristName
			  END
			ELSE IF (
						SELECT COUNT([s].[Id]) 
						  FROM [Sites] 
							AS [s]
						  JOIN [SitesTourists] 
							AS [st] 
							ON [s].[Id] = [st].[SiteId]
						  JOIN [Tourists] 
							AS [t] 
							ON [t].[Id] = [st].[TouristId]
						 WHERE [t].[Name] = @TouristName) 
				>= 50
			BEGIN 
				UPDATE [Tourists]
				   SET [Reward] = 'Silver badge'
				 WHERE [Name] = @TouristName
			  END
			ELSE IF (
					SELECT COUNT([s].[Id]) 
					  FROM [Sites] 
					    AS [s]
					  JOIN [SitesTourists] 
					    AS [st] 
						ON [s].[Id] = [st].[SiteId]
					  JOIN [Tourists] 
					    AS [t] 
						ON [t].[Id] = [st].[TouristId]
					 WHERE [t].[Name] = @TouristName) 
				>= 25
			BEGIN 
				UPDATE [Tourists]
				   SET [Reward] = 'Bronze badge'
				 WHERE [Name] = @TouristName
			  END
			
			SELECT [Name], 
				   [Reward] 
			  FROM [Tourists]
			 WHERE [Name] = @TouristName
		END;

EXEC [usp_AnnualRewardLottery] 'Gerhild Lutgard';

EXEC [usp_AnnualRewardLottery] 'Brus Brown';

EXEC [usp_AnnualRewardLottery] 'Zac Walsh';

EXEC [usp_AnnualRewardLottery] 'Teodor Petrov';
