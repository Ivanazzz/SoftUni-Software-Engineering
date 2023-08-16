SELECT *
  INTO [EmployeesWithSalaryOver30000]
  FROM [Employees]
 WHERE [Salary] > 30000;

DELETE
  FROM [EmployeesWithSalaryOver30000]
 WHERE [ManagerID] = 42;

UPDATE [EmployeesWithSalaryOver30000]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1;

  SELECT [DepartmentID],
		 AVG([Salary])
	  AS [AverageSalary]
    FROM [EmployeesWithSalaryOver30000]
GROUP BY [DepartmentID];