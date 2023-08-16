CREATE FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50))
	RETURNS BIT
			 AS
		  BEGIN
				DECLARE @wordIndex INT = 1;
				WHILE (@wordIndex <= LEN(@word))
				BEGIN
					DECLARE @currentCharacter CHAR = SUBSTRING(@word, @wordIndex, 1);

					IF (CHARINDEX(@currentCharacter, @setOfLetters) = 0)
					BEGIN
						RETURN 0;
					END

					SET @wordIndex += 1;
				END

				RETURN 1;
		    END;

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia');
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'halves');
SELECT [dbo].[ufn_IsWordComprised]('bobr', 'Rob');
SELECT [dbo].[ufn_IsWordComprised]('pppp', 'Guy');