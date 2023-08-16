CREATE PROC [usp_SearchByAirportName] @airportName VARCHAR(70)
		 AS
	  BEGIN
			  SELECT [ap].[AirportName],
					 [p].[FullName],
					 CASE
					    WHEN [fd].[TicketPrice] <= 400
						THEN 'Low'
						WHEN [fd].[TicketPrice] BETWEEN 401 AND 1500
						THEN 'Medium'
						WHEN [fd].[TicketPrice] > 1500
						THEN 'High'
					 END
				  AS [LevelOfTicketPrice],
					 [ac].[Manufacturer],
					 [ac].[Condition],
					 [at].[TypeName]
				FROM [Airports]
			      AS [ap]
				JOIN [FlightDestinations]
			      AS [fd]
				  ON [ap].[Id] = [fd].[AirportId]
				JOIN [Aircraft]
			      AS [ac]
				  ON [ac].[Id] = [fd].[AircraftId]
				JOIN [Passengers]
				  AS [p]
				  ON [p].[Id] = [fd].[PassengerId]
				JOIN [AircraftTypes]
				  AS [at]
				  ON [at].[Id] = [ac].[TypeId]
			   WHERE [ap].[AirportName] = @airportName
			ORDER BY [ac].[Manufacturer] ASC,
					 [p].[FullName] ASC
		END;

EXEC [usp_SearchByAirportName] 'Sir Seretse Khama International Airport';