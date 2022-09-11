Select v.JobTitle as 'Должность', count(*) as 'Кол-во сотрудников'
From [stud10AdwentureWorks].[dbo].[vEmp_Person] as v
Group BY v.JobTitle 
Having count(v.JobTitle)>10
Order by v.JobTitle