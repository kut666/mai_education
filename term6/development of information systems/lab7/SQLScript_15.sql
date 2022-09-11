SELECT *
FROM [AdventureWorks2019].[HumanResources].[Employee] as e
Where e.HireDate > ANY(Select e1.HireDate
                   From [AdventureWorks2019].[HumanResources].[Employee] as e1
				   Where e1.BirthDate between '1990-01-01' and '2000-01-01')
go