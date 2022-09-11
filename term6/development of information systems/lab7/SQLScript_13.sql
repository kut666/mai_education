Select p.FirstName, p.LastName
From Person.Person as p
Where p.BusinessEntityID in
	(Select e.BusinessEntityID
	From HumanResources.Employee as e
    Where e.HireDate between '2008-01-01' and '2008-12-31'
    and year(e.HireDate)-year(e.BirthDate) < 30)
go

