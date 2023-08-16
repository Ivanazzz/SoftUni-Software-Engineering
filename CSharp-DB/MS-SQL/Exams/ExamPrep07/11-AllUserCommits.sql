CREATE FUNCTION [udf_AllUserCommits](@username VARCHAR(30))
    RETURNS INT
			 AS
		  BEGIN
				DECLARE @userId INT = (
										  SELECT [Id]
											FROM [Users]
										   WHERE [Username] = @username
									  );

				DECLARE @commitsCount INT = (
												SELECT COUNT([Id])
												  FROM [Commits]
												 WHERE [ContributorId] = @userId
											);
				RETURN @commitsCount;
		    END;

SELECT [dbo].[udf_AllUserCommits]('UnderSinduxrein');