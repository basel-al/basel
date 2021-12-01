select ProductID, Name, Color, ListPrice from Production.Product


select ProductID, Name, Color, ListPrice from Production.Product where ListPrice != 0


select ProductID, Name, Color, ListPrice from Production.Product where Color is null


select ProductID, Name, Color, ListPrice from Production.Product where Color is not null


select ProductID, Name, Color, ListPrice from Production.Product where Color is not null and ListPrice > 0


select ProductID, Name + ' ' + isNull(Color, '') from Production.Product


select ProductID, Name, Color from Production.Product  where ProductID < 323 and Color is not null


select ProductID, Name, Color from Production.Product where ProductID between 400 and 500


select ProductID, Name, Color from Production.Product where Color like 'Blue' or Color like 'Black'


select ProductID, Name  from Production.Product where Name like 'S%'


select ProductID, Name, ListPrice  from Production.Product order by Name


select ProductID, Name, ListPrice  from Production.Product where Name like 'A%' or Name like 'S%' order by Name


select ProductID, Name, ListPrice  from Production.Product where Name like 'Spo[^k]%' order by Name


select distinct Color  from Production.Product order by color desc


select distinct ProductSubcategoryID, Color from Production.Product where ProductSubcategoryID is not null and Color is not null

