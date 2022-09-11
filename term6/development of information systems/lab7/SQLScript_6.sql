Select*
From [AdventureWorks2019].[HumanResources].[JobCandidate] as j
Where j.BusinessEntityID IS NULL
go

Select*
From [AdventureWorks2019].[HumanResources].[JobCandidate] as j
Where j.BusinessEntityID IS NOT NULL
go