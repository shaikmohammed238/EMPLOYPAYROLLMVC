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
EXEC EmpPayINSERT(@Name,@Profile,@Gender,@Department,@Salary,@Startdate,@Notes)-----------string give name------
----for update store procedure
alter  PROC sp_EmpPayUPDATE( 
	 @EmpId int,      
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
							Notes=@Notes where EmpId=@EmpId
END;
-----------GET ALL PROC
CREATE PROC EmpPayGETALL
AS
BEGIN
SELECT * FROM EmployeePayrollForm
ORDER BY EmpId
END
-------DELETE PROC 
Alter PROC sp_EmpPayDEL(@EmpId Int)
AS
begin
DELETE FROM EmployeePayrollForm WHERE EmpId=@EmpId
END
---------GETBYID PROC
Alter PROC sp_EmpPayGETBYID(@EmpId Int)
AS
begin
SELECT * FROM EmployeePayrollForm WHERE EmpId=@EmpId
END
------
alter table EmployeePayrollForm
alter column ProfileImage varchar(100);
 exec sp_EmpPayDEL @EmpId=1;