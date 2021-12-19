USE acme
GO

SET IDENTITY_INSERT acme.dbo.Person ON


INSERT INTO acme.dbo.Person
(PersonId, LastName, FirstName, BirthDate)
VALUES
 (1,'Doe', 'John', '1997-01-21'),
 (2,'Soap', 'Bill', '2001-06-18'),
 (3,'Musa', 'Viwe', '1996-02-07'),
 (4,'Zulu', 'Charlie', '2002-01-11'),
 (5,'Mols', 'Anka', '1987-05-17');

SET IDENTITY_INSERT acme.dbo.Person OFF

