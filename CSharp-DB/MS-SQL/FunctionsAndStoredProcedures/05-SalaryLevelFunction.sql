CREATE FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR (8)
			 AS
		  BEGIN
			    DECLARE @salaryLevel VARCHAR(8);

				IF (@salary < 30000)
				BEGIN
					SET @salaryLevel = 'Low';
				END
				ELSE IF (@salary BETWEEN 30000 AND 50000)
				BEGIN
					SET @salaryLevel = 'Average';
				END
				ELSE IF (@salary > 50000)
				BEGIN
					SET @salaryLevel = 'High';
				END

				RETURN @salaryLevel;
		    END;

SELECT [Salary],
	   [dbo].[ufn_GetSalaryLevel]([Salary])
	AS [Salary Level]
  FROM [Employees];