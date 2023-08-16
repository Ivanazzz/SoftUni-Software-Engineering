  SELECT [ap].[AirportName],
		 [fd].[Start]
	  AS [DayTime],
		 [fd].[TicketPrice],
		 [p].[FullName],
		 [ac].[Manufacturer],
		 [ac].[Model]
	FROM [FlightDestinations]
      AS [fd]
	JOIN [Airports]
      AS [ap]
      ON [ap].[Id] = [fd].[AirportId]
	JOIN [Passengers]
      AS [p]
	  ON [p].[Id] = [fd].[PassengerId]
	JOIN [Aircraft]
      AS [ac]
	  ON [ac].[Id] = [fd].[AircraftId]
   WHERE DATEPART(HOUR, [fd].[Start]) BETWEEN 6 AND 20
	 AND [fd].[TicketPrice] > 2500
ORDER BY [ac].[Model] ASC;