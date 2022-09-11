Create View vEmp_Person as
SELECT *       
FROM  HumanResources.Employee AS e INNER JOIN
      Person.Person as p ON e.BusinessEntityID = p.BusinessEntityID