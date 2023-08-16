  SELECT *
    FROM (
			    SELECT [p].[FullName],
					   COUNT(*)
				    AS [CountOfAircraft],
					   SUM([fd].[TicketPrice])
				    AS [TotalPaid]
				  FROM [Passengers]
				    AS [p]
			  	  JOIN [FlightDestinations]
				    AS [fd]
				    ON [p].[Id] = [fd].[PassengerId]
				  JOIN [Aircraft]
				    AS [a]
				    ON [a].[Id] = [fd].[AircraftId]
			     WHERE [p].[FullName] LIKE '_a%'
			  GROUP BY [p].[FullName]
	     )
	  AS [FlightsSubqery]
   WHERE [CountOfAircraft] > 1
ORDER BY [FullName];