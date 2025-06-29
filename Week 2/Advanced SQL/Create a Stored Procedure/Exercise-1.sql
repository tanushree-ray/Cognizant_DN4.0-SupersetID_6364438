
--STEP-1

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees e
    INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DepartmentID;
END;


EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;


--STEP-2

SELECT 
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName,
    e.Salary,
    e.JoinDate
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 2;  

--STEP-3

CREATE PROCEDURE sp_InsertEmployee 
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @DepartmentID INT, 
    @Salary DECIMAL(10,2), 
    @JoinDate DATE 
AS 
BEGIN 
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate); 
END;

EXEC sp_InsertEmployee 
    @FirstName = 'Aarav', 
    @LastName = 'Mehta', 
    @DepartmentID = 3, 
    @Salary = 6200.00, 
    @JoinDate = '2024-08-10';

EXEC sp_InsertEmployee 
    @FirstName = 'Aarav', 
    @LastName = 'Mehta', 
    @DepartmentID = 3, 
    @Salary = 6200.00, 
    @JoinDate = '2024-08-10';

    SELECT * FROM Employees WHERE FirstName = 'Aarav' AND LastName = 'Mehta';

