CREATE OR ALTER PROC [usp_DeleteEmployeesFromDepartment] @departmentId INT
   				  AS
   			   BEGIN
   				 	 -- We need to store all id's of the Employees that are going to be removed.
   					 DECLARE @employeesToDelete TABLE ([Id] INT);
   					 INSERT INTO  @employeesToDelete
   								  SELECT [EmployeeID] 
   								    FROM [Employees]
   								   WHERE [DepartmentID] = @departmentId;
   
   					 -- Employees which are we going to remove can be working on some projetcs.
   					 -- So we need to remove them from working on these projetcs.
   					 DELETE 
   					   FROM [EmployeesProjects]
   					  WHERE [EmployeeID] IN (
   												 SELECT *
   												   FROM @employeesToDelete
   										    );
   
   					 -- Employees which are we going to remove can be Managers in some Departments.
   					 -- So we need to set ManagerID NULL of all Departments with futurely deleted Managers.
   					 -- First we need to alter column ManagerID.
   					  ALTER TABLE [Departments]
   					 ALTER COLUMN [ManagerID] INT;
   
   					 UPDATE [Departments]
   					    SET [ManagerID] = NULL
   					  WHERE [ManagerID] IN (
   												 SELECT *
   												   FROM @employeesToDelete
   										   );
   
   					 -- Employees which are we going to remove can be Managers of another Employees.
   					 -- So we need to set ManagerID to NULL of all Employees with futurely deleted Managers.
   					 UPDATE [Employees]
   					    SET [ManagerID] = NULL
   					  WHERE [ManagerID] IN (
   												 SELECT *
   												   FROM @employeesToDelete
   										   );
   
   					 -- Since we removed all references to the Employees we want to remove
   					 -- We can safely remove them.
   					 DELETE
   					   FROM [Employees]
   					  WHERE [DepartmentID] = @departmentId;
   
   					 -- Then we delete the Departments from the Departments table.
   					 DELETE
   					   FROM [Departments]
   					  WHERE [DepartmentID] = @departmentId;
   
   					 SELECT COUNT(*)
   					   FROM [Employees]
   					  WHERE [DepartmentID] = @departmentId;
   				 END;

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 7;