CREATE TABLE EmployeePayrollForm(EmpId INT IDENTITY  NOT NULL-----------TABLE CREATE
,[Name] VARCHAR(100) NOT NULL
,ProfileImage VARBINARY(MAX) NOT NULL
,Gender VARCHAR(100)NOT NULL
,Department VARCHAR(100) NOT NULL
,Salary BIGINT Default'0'
,Startdate DATETIME NOT NULL
,Notes VARCHAR(200));
-----------CREATING STORE PROCEDURE-------------
CREATE  PROC EmpPayINSERT(        
    @Name VARCHAR(100),         
    @Profile VARCHAR(100),
	@Gender VARCHAR(100) ,       
    @Department VARCHAR(100),
	@Salary BIGINT, 
	@Startdate DATETIME,
	@Notes VARCHAR(200)       
)        
AS
BEGIN
INSERT INTO EmployeePayrollForm([Name],ProfileImage,Gender,Department,Salary,Startdate,Notes)
VALUES (@Name,@Profile,@Gender,@Department,@Salary,@Startdate,@Notes)
END;
---execute procedure 
EXEC EmpPayINSERT(@Name,@Profile,@Gender,@Department,@Salary,@Startdate,@Notes)
----for update store procedure
CREATE  PROC EmpPayUPDATE( 
	       
    @Name VARCHAR(100),         
    @Profile VARCHAR(100),
	@Gender VARCHAR(100) ,       
    @Department VARCHAR(100),
	@Salary BIGINT, 
	@Startdate DATETIME,
	@Notes VARCHAR(200)       
)        
AS
BEGIN
UPDATE EmployeePayrollForm SET 
							[Name]=@Name,
							ProfileImage=@Profile,
							Gender=@Gender,
                            Department=@Department,
							Salary=@Salary,
                           Startdate=@Startdate,
							Notes=@Notes
END;
-----------GET ALL PROC
CREATE PROC EmpPayGETALL
AS
BEGIN
SELECT * FROM EmployeePayrollForm
ORDER BY EmpId
END
-------DELETE PROC 
CREATE PROC EmpPayDEL(@Id Int)
AS
begin
DELETE FROM EmployeePayrollForm WHERE EmpId=@Id
END
---------GETBYID PROC
CREATE PROC EmpPayGETBYID(@Id Int)
AS
begin
SELECT * FROM EmployeePayrollForm WHERE EmpId=@Id
END
------
alter table EmployeePayrollForm
alter column ProfileImage varchar(100);