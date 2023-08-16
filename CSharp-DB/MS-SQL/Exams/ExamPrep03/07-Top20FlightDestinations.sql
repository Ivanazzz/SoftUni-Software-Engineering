  SELECT 
TOP (20) [fd].[Id]
	  AS [DestinationId],
		 [fd].[Start],
		 [p].[FullName],
		 [a].[AirportName],
		 [fd].[TicketPrice]
	FROM [FlightDestinations]
	  AS [fd]
	JOIN [Passengers]
      AS [p]
	  ON [p].[Id] = [fd].[PassengerId]
	JOIN [Airports]
      AS [a]
	  ON [a].[Id] = [fd].[AirportId]
   WHERE DAY([fd].[Start]) % 2 = 0
ORDER BY [fd].[TicketPrice] DESC,
		 [a].[AirportName] ASC;