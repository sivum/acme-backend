USE acme

GO

CREATE TABLE dbo.Person(
 [PersonId] INT IDENTITY (1,1) NOT NULL,
 [LastName] nvarchar(55) NOT NULL,
 [FirstName] nvarchar(55) NOT NULL,
 [BirthDate] datetime2 NOT NULL,
 CONSTRAINT[PK_Person] PRIMARY KEY CLUSTERED
 (
 	[PersonId] ASC
 )
)

CREATE TABLE Employee(
 [EmployeeId] INT IDENTITY (1,1) NOT NULL,
 [PersonId] INT NOT NULL,
 [EmployeeNum] nvarchar(25) NOT NULL,
 [EmployedDate] datetime2 NOT NULL,
 [Terminated] datetime2,
 CONSTRAINT[PK_Employee] PRIMARY KEY CLUSTERED
 ([EmployeeId] ASC)
)

ALTER TABLE Employee WITH CHECK ADD CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId])
REFERENCES dbo.Person([PersonId])
ON DELETE CASCADE


