USE SoftUni
GO

UPDATE [Employees]
   SET [Salary] += [Salary] * 0.12
 WHERE [DepartmentID] IN (1, 2, 4, 11);

GO

SELECT [Salary]
  FROM [Employees];


-- ADVANCED SOLUTION

UPDATE [Employees]
   SET [Salary] += [Salary] * 0.12
 WHERE [DepartmentID] IN 
                         (
							SELECT [DepartmentID]
							  FROM [Departments]
							 WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
						 );

SELECT [Salary]
  FROM [Employees];