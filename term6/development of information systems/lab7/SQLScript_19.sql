Select e.JobTitle, count(*) as 'Кол-во сотрудников'
From [AdventureWorks2019].[HumanResources].[Employee] as e
Group BY e.JobTitle
Having count(e.JobTitle)>3
Order by e.JobTitle