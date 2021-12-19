USE acme
GO

SET IDENTITY_INSERT acme.dbo.Employee ON

INSERT INTO acme.dbo.Employee
(PersonId,EmployeeId, EmployeeNum, EmployedDate, Terminated)
VALUES
(1,1, 'AC01', GETDATE() , NULL),
(2,2, 'AC02', GETDATE() , NULL),
(3,3, 'AC03', GETDATE(), NULL),
(4,4, 'AC04', GETDATE(), NULL),
(5,5, 'AC05', GETDATE(), NULL);

SET IDENTITY_INSERT acme.dbo.Employee OFF
