CREATE PROC [usp_GetTownsStartingWith] @string VARCHAR(20)
		 AS
	  BEGIN
			SELECT [Name]
		      FROM [Towns]
			 WHERE [Name] LIKE CONCAT(@string, '%')
	    END;

EXEC [dbo].[usp_GetTownsStartingWith] 'b'