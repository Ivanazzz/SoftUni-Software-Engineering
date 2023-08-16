-- Method 1
SELECT *
  FROM (
	         SELECT [DepartmentID],
				    MAX([Salary])
				 AS [MaxSalary]
			   FROM [Employees]
		   GROUP BY [DepartmentID]
	   )
	AS [DepartmentMaxSalary]
 WHERE [MaxSalary] NOT BETWEEN 30000 AND 70000;

-- Method 2
  SELECT [DepartmentID],
	     MAX([Salary])
	  AS [MaxSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000;