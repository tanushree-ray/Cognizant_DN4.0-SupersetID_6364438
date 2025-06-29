
--STEP-1
CREATE PROCEDURE sp_CountEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 'Procedure created'; -- Temporary stub
END;

--STEP-2

DECLARE @DepartmentID INT = 3;

SELECT COUNT(*) AS TotalEmployees
FROM Employees
WHERE DepartmentID = @DepartmentID;


--STEP-3
ALTER PROCEDURE sp_CountEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_CountEmployeesByDepartment @DepartmentID = 3;
