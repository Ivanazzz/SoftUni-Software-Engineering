CREATE FUNCTION [udf_GetVolunteersCountFromADepartment](@VolunteersDepartment VARCHAR(30))
	RETURNS INT
			 AS
		  BEGIN
				DECLARE @departmentId INT = (
												SELECT [Id]
												  FROM [VolunteersDepartments]
												 WHERE [DepartmentName] = @VolunteersDepartment
											);

				DECLARE @count INT = (
									       SELECT COUNT(*)
				                             FROM [Volunteers]
									        WHERE [DepartmentId] = @departmentId
								 );

				RETURN @count;
		    END;

SELECT [dbo].[udf_GetVolunteersCountFromADepartment]('Education program assistant');

SELECT [dbo].[udf_GetVolunteersCountFromADepartment]('Guest engagement');

SELECT [dbo].[udf_GetVolunteersCountFromADepartment]('Zoo events');