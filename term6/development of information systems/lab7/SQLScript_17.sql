Select AVG(year(SYSDATETIME())-year(e.BirthDate)) as 'average age'
From [AdventureWorks2019].[HumanResources].[Employee] as e