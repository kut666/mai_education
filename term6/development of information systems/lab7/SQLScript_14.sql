SELECT *
FROM [AdventureWorks2019].[HumanResources].[Employee] as e
where e.HireDate > ALL (SELECT e1.HireDate
FROM [AdventureWorks2019].[HumanResources].[Employee] as e1
where e1.BirthDate between '1990-01-01' and '2000-01-01')
