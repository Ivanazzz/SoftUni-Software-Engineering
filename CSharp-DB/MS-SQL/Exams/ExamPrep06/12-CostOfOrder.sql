CREATE FUNCTION [udf_GetCost](@jobId INT)
RETURNS DECIMAL (8, 2)
			 AS
		  BEGIN
				DECLARE @totalCost DECIMAL(8, 2);
				DECLARE @jobOrdersCount INT	= (
													   SELECT COUNT([o].[OrderId])
													     FROM [Jobs]
													       AS [j]
													LEFT JOIN [Orders]
														   AS [o]
														   ON [j].[JobId] = [o].[JobId]
														WHERE [j].[JobId] = @jobId
				);

				IF @jobOrdersCount = 0
				BEGIN
					RETURN 0;
				END	

				SET @totalCost = (
										   SELECT SUM([p].[Price] * [op].[Quantity])
										     FROM [Jobs]
										       AS [j]
										LEFT JOIN [Orders]
											   AS [o]
											   ON [j].[JobId] = [o].[JobId]
										LEFT JOIN [OrderParts]
											   AS [op]
											   ON [o].[OrderId] = [op].[OrderId]
										LEFT JOIN [Parts]
											   AS [p]
											   ON [op].[PartId] = [p].[PartId]
											WHERE [j].[JobId] = @jobId
				);

				RETURN @totalCost;
		    END;

SELECT [dbo].[udf_GetCost](1);