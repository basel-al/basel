
/*
1.	A result set is the output of a query, or a set of records that includes metadata like column names, sizes and types.
2.	Union removes duplicates while Union All does not. Union sorts by the order of first column by default while Union will remain the original sequence by default.
3.	EXCEPT and INTERSECT
4.	Union combines multiple SELECT statement queries into new rows. Join is used to combine data from multiple tables into new columns. The number of rows depends on the kinds of joins and the queries.
5.	INNER JOIN will return the rows that has matched elements in both queries. FULL JOIN will return all the rows of both queries combined.
6.	Left join is a type of outer join. Left outer join will return all rows from left query, even if they have no matches with the right query
7.	Cross join returns the cartesian product (number of rows in first table multiplied by number on right).
8.	WHERE only works on columns that already exist in original queries, usually after FROM. Having can be used on columns not included the in original query.
9.	yes. If that happens the columns SQL will put the rows with the same values in all those columns in the same group.
*/
/*
Aggregate Functions
*/
1
select count(ProductID) as Products FROM Production.Product as P
WHERE P.ProductSubcategoryID is not null
2
select count(ProductID) as "Number of Products in A Category" 
FROM Production.Product as P
WHERE P.ProductSubcategoryID is not null
3
select ProductSubcategoryID, count(ProductID) as "Counted Products"
FROM Production.Product as P
WHERE P.ProductSubcategoryID is not null
GROUP BY ProductSubcategoryID;
4
select ProductSubcategoryID, count(ProductID) as "Number of Products without ID"
FROM Production.Product as P
WHERE P.ProductSubcategoryID is null
GROUP BY ProductSubcategoryID;
5
select ProductID, sum(Quantity) as TheSum
FROM Production.ProductInventory
WHERE LocationID ='40'
GROUP BY ProductID
HAVING sum(Quantity) < 100;
6
select Shelf, ProductID, sum(Quantity) as TheSum
FROM Production.ProductInventory
WHERE LocationID ='40'
GROUP BY ProductID, Shelf
HAVING sum(Quantity) < 100;
7
select ProductID, avg(Quantity) as TheAvg
FROM Production.ProductInventory
WHERE LocationID ='10'
GROUP BY ProductID
8
select ProductID, Shelf, avg(Quantity) as TheAvg
FROM Production.ProductInventory
GROUP BY ProductID,Shelf
9
select ProductID, Shelf, avg(Quantity) as TheAvg
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID,Shelf
10
select Color, Class, count(*) , avg(ListPrice) as AvgPrice
FROM Production.Product
WHERE Color is not null and Class is not null
GROUP BY Color, Class
11
select c.Name as Country, s.Name as Province 
FROM Person.CountryRegion c 
JOIN Person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode;

/*
Joins:
*/
12
SELECT c.Name AS Country, s.Name AS Province 
FROM Person.CountryRegion c 
JOIN Person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode;
13
SELECT c.Name AS Country, s.Name AS Province 
FROM Person.CountryRegion c 
JOIN Person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name not in ('Germany', 'Canada');

/*
Northwind
*/
14
SELECT distinct p.ProductID, p.ProductName
FROM Orders o
JOIN [Order Details] od on o.OrderID =  od.OrderID
JOIN Products p on od.ProductID = p.ProductID
WHERE datediff(year, o.OrderDate, GETDATE()) < 25
15	
SELECT top 5 o.ShipPostalCode, sum(od.Quantity) as qty 
FROM Orders o
JOIN [Order Details] od
ON o.OrderID =  od.OrderID
WHERE o.ShipPostalCode is not null
GROUP BY ShipPostalCode
ORDER BY qty desc
16
SELECT top 5 o.ShipPostalCode, sum(od.Quantity) as qty
FROM Orders o
JOIN [Order Details] od
ON o.OrderID =  od.OrderID
WHERE o.ShipPostalCode is not null and datediff(year, o.OrderDate, GETDATE())< 25
GROUP BY ShipPostalCode
ORDER BY qty desc
17
select City, count(customerID) as NumOfCustomer
from customers
group by City
18
select City, count(customerID) as NumOfCustomer
FROM Customers
GROUP BY City
HAVING count(customerID)>2
19
SELECT distinct c.CustomerID, c.CompanyName, c.ContactName 
FROM Orders o
INNER JOIN Customers c on o.CustomerID = c.CustomerID
WHERE OrderDate > '1998-1-1';
20
SELECT c.ContactName, MAX(o.OrderDate) as MostRecentOrderDate
FROM Customers c 
LEFT JOIN Orders o on c.CustomerId = o.CustomerId
GROUP BY c.ContactName
21
SELECT c.CustomerID, c.CompanyName, c.ContactName, 
SUM(od.Quantity) as QTY
FROM Customers c 
LEFT JOIN Orders o on c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY c.CustomerID, c.CompanyName, c.ContactName
ORDER BY QTY
22
SELECT c.CustomerID, sum(od.Quantity) as QTY
FROM Customers c 
LEFT JOIN Orders o on c.CustomerID = o.CustomerID
LEFT JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING SUM(od.Quantity) > 100
ORDER BY QTY
23
SELECT distinct sup.CompanyName, ship.CompanyName 
FROM Orders o 
LEFT JOIN [Order Details] od on o.OrderID = od.OrderID
INNER JOIN Products p on od.ProductID = p.ProductID
RIGHT JOIN Suppliers sup on p.SupplierID = sup.SupplierID
INNER JOIN Shippers ship on o.ShipVia = ship.ShipperID;
24
SELECT o.OrderDate, p.ProductName 
FROM Orders o
LEFT JOIN [Order Details] od on o.OrderID = od.OrderID
INNER JOIN Products p on od.ProductID = p.ProductID
GROUP BY o.OrderDate, p.ProductName
ORDER BY o.OrderDate
25
SELECT e1.Title, e1.LastName + ' ' + e1.FirstName as Name1, e2.LastName + ' ' + e2.FirstName as Name2 
FROM Employees e1
JOIN Employees e2 on e1.Title = e2.Title 
WHERE e1.FirstName != e2.FirstName or e1.LastName != e2.LastName
ORDER BY Title;
26
SELECT T1.EmployeeId, T1.LastName, T1.FirstName,T2.ReportsTo, count(T2.ReportsTo) as Subordinate  
FROM Employees T1 JOIN Employees T2 on T1.EmployeeId = T2.ReportsTo
WHERE T2.ReportsTo is not null
GROUP BY T1.EmployeeId, T1.LastName, T1.FirstName,T2.ReportsTo
HAVING count(T2.ReportsTo) > 2
27
SELECT c.City, c.CompanyName, c.ContactName, 'Customer' as Type
FROM Customers c
UNION
SELECT s.City, s.CompanyName, s.ContactName, 'Supplier' as Type
FROM Suppliers s
