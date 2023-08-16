-- Method 1
SELECT [FirstName],
		[LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%';

 -- Method 2
SELECT [FirstName],
		[LastName]
  FROM [Employees]
 WHERE CHARINDEX('ei', [LastName]) > 0;