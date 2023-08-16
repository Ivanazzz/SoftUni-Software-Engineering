CREATE FUNCTION [udf_ClientWithCigars](@name NVARCHAR(30))
	RETURNS INT
			 AS
		  BEGIN
				RETURN (
							SELECT COUNT(*)
							  FROM [ClientsCigars]
							    AS [cc]
							  JOIN [Clients]
							    AS [c]
								ON [c].[Id] = [cc].[ClientId]
							 WHERE [c].[FirstName] = @name
						);
			END;

SELECT [dbo].[udf_ClientWithCigars]('Betty');