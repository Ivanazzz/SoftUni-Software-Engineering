CREATE PROC [usp_SearchForFiles] @fileExtension VARCHAR(100)
		 AS
	  BEGIN
			   SELECT [Id],
				      [Name],
				      CONCAT([Size], 'KB')
				   AS [Size]
			     FROM [Files]
				   AS [f]
			    WHERE [Name] LIKE CONCAT('%[.]', @fileExtension)
			 ORDER BY [Id] ASC,
			          [Name] ASC,
			          [f].[Size] DESC
		END;

EXEC [usp_SearchForFiles] 'txt';