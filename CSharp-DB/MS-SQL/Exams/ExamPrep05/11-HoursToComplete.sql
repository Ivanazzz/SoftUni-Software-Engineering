CREATE FUNCTION [udf_HoursToComplete](@StartDate DATETIME, @EndDate DATETIME)
	RETURNS INT
			 AS
		  BEGIN
				DECLARE @hours INT = (
										 SELECT IIF(DATEDIFF(HOUR, @StartDate, @EndDate) IS NULL, 0, DATEDIFF(HOUR, @StartDate, @EndDate))
				);

				RETURN @hours;
		    END;

SELECT [dbo].[udf_HoursToComplete]([OpenDate], [CloseDate]) 
	AS [TotalHours]
  FROM [Reports];
