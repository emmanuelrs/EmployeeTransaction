-------------------------------------------------------
-- Store Procedures Práctica Emmanuel Rosales
-------------------------------------------------------

------
-- Insert Employee Procedure
------

CREATE PROCEDURE employee_registration
(@employee_id NUMERIC(30), @employee_name VARCHAR(50), @employee_first_surname VARCHAR(50),
@employee_second_surname VARCHAR(50), @employee_email VARCHAR(50), @employee_username VARCHAR(50),
@employee_salary NUMERIC(30))
AS
BEGIN
	INSERT INTO [dbo].[employee]([employee_id], [employee_name],[employee_first_surname]
           ,[employee_second_surname],[employee_email],[employee_username],[employee_salary])

     VALUES(@employee_id, @employee_name,@employee_first_surname,@employee_second_surname,
	  @employee_email,  @employee_username, @employee_salary); 
END

------
-- Get Employee Procedure
------

CREATE PROCEDURE get_employee_info
AS
BEGIN
	SELECT *
    FROM [transaction_system].[dbo].[employee];
END

