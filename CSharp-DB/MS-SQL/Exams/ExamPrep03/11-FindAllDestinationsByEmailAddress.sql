CREATE FUNCTION [udf_FlightDestinationsByEmail](@email VARCHAR(50))
    RETURNS INT
			 AS
		  BEGIN
				DECLARE @count INT = (
									  SELECT COUNT(*)
										FROM [FlightDestinations]
										  AS [fd]
										JOIN [Passengers]
										  AS [p]
										  ON [p].[Id] = [fd].[PassengerId]
									   WHERE [p].[Email] = @email
									  );

				RETURN @count;
		    END;

SELECT [dbo].[udf_FlightDestinationsByEmail]('PierretteDunmuir@gmail.com');

SELECT [dbo].[udf_FlightDestinationsByEmail]('Montacute@gmail.com');

SELECT [dbo].[udf_FlightDestinationsByEmail]('MerisShale@gmail.com');