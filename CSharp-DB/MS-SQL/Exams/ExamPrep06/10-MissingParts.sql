  SELECT *
    FROM (
			       SELECT [p].[PartId],
					      [p].[Description],
					      [pn].[Quantity]
				       AS [Required],
					      [p].[StockQty]
				       AS [In Stock],
					      ISNULL([op].[Quantity], 0)
				       AS [Ordered]
					 FROM [Jobs]
					   AS [j]
				LEFT JOIN [PartsNeeded]
					   AS [pn]
					   ON [j].[JobId] = [pn].[JobId]
				LEFT JOIN [Parts]
					   AS [p]
					   ON [p].[PartId] = [pn].[PartId]
				LEFT JOIN [Orders]
					   AS [o]
					   ON [j].[JobId] = [o].[JobId]
				LEFT JOIN [OrderParts]
					   AS [op]
					   ON [o].[OrderId] = [op].[OrderId]
					WHERE [j].[Status] <> 'Finished'
					  AND ([o].[Delivered] = 0
					   OR [o].[Delivered] IS NULL)
	     )
	  AS [PartsQuantitySubquery]	
   WHERE [Required] > [In Stock] + [Ordered]
ORDER BY [PartId];