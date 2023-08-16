CREATE FUNCTION [udf_CreatorWithBoardgames](@name NVARCHAR(30))
	RETURNS INT
			 AS
		  BEGIN
				DECLARE @count INT = (
											  SELECT COUNT(*)
											    FROM [Creators]
											      AS [c]
											    JOIN [CreatorsBoardgames]
											      AS [cb]
												  ON [c].[Id] = [cb].[CreatorId]
											   WHERE [c].[FirstName] = @name
									 );

				RETURN @count;
		    END;

SELECT [dbo].[udf_CreatorWithBoardgames]('Bruno');