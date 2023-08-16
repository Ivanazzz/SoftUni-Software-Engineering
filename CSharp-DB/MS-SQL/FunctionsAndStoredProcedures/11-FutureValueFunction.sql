CREATE FUNCTION [ufn_CalculateFutureValue](@sum DECIMAL(12, 4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL (12, 4)
			 AS
		  BEGIN
				RETURN @sum * POWER((1 + @yearlyInterestRate), @numberOfYears);
		    END;

SELECT [dbo].[ufn_CalculateFutureValue](1000, 0.1, 5);