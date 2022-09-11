Select*
From HumanResources.Employee as e
where e.HireDate between '2008-01-01' and '2008-12-31'
and year(e.HireDate) - year(e.BirthDate) < 30
go



