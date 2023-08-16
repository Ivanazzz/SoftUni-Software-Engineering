-- Method 1
SELECT [FirstName],
		[LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%';

 -- Method 2
SELECT [FirstName],
		[LastName]
  FROM [Employees]
 WHERE CHARINDEX('engineer', [JobTitle]) = 0;