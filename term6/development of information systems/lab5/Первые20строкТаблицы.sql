/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (20) [BusinessEntityID]
      ,[AddressID]
      ,[AddressTypeID]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2019].[Person].[BusinessEntityAddress]