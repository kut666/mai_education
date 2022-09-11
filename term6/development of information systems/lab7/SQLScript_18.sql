Select AVG(year(SYSDATETIME())-year(e.BirthDate)) as 'avg age', e.Gender
From [AdventureWorks2019].[HumanResources].[Employee] as e
Group BY e.Gender