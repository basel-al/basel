/*
1. Join becauase it will likely be more efficient
2. CTE is a temporary result set that exists in scope for one execution of select,insert,update, delete, or merge. They should be used when only one operation needs to be done with a result set.
3. Table variables are data types that store temporary data. Their scope is the entire session and they are created in tempDB.
4. Delete is slower but more versatile because it collects rollback data and is used with WHERE. Truncate is used with WITH.
5. The autopopulated increasing column of a table. Delete does not but truncate will reset the identity properties.
*/
Use Northwind
1. 
select  distinct c.City from 
dbo.Customers as c inner join dbo.Employees as e
on c.City = e.City


2
select distinct c.City 
from Customers c left join Employees e
on c.City = e.city 
where e.city is null

3
select p.ProductID, p.ProductName, count(p.ProductID)
from Products p inner join [Order Details] od on p.ProductID = od.ProductID
group by p.ProductID, p.ProductName

4
/*
select o.OrderID, c.City, od.Quantity
from Orders o join Customers c on o.CustomerID = c.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
order by c.City
*/
select c.City, sum(od.Quantity)
from Orders o join Customers c on o.CustomerID = c.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
group by c.City
order by c.City

5 
select City, count(City) from Customers
group by City having count(City)>1


--6.	List all Customer Cities that have ordered at least two different kinds of products.
/*
select o.OrderID, c.CustomerID, c.City, ProductID
from Orders o join Customers c on o.CustomerID = c.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
order by c.City
*/

select c.City 
from Orders o join Customers c on o.CustomerID = c.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
group by c.City
having count(c.City) > 1
order by c.City


7

select distinct c.ContactName, c.City, o.ShipCity
from Orders o join Customers c on o.CustomerID = c.CustomerID
where c.City != o.ShipCity

8

with mid
as
(
select top 5 od.ProductID, sum(od.Quantity) as Total
from Orders o join [Order Details] od on o.OrderID = od.OrderID
group by od.ProductID
order by Total desc
)
select p.ProductID, p.ProductName, mid.Total 
from Products p join mid on p.ProductID = mid.ProductID

9
select e.City
from Employees e left join Orders o
on e.City = o.ShipCity 
where o.ShipCity is null

10
select o.ShipCity
from Orders o
group by o.ShipCity
order by count(o.ShipCity) desc
limit 5

11
--Using a CTE with ROW_NUMBER() and partitions you can group the duplicates and delete the extras

12
select mgrid 
from Employee 
where mgrid is null

13
with mid
as
(
select count(e.deptID) as empcount, d.deptname
from Employee e join Dept d 
on e.deptID = d.deptID
group by e.deptID
order by d.deptname
)
with mds
as
(
select count(e.deptID) as empcount, d.deptname
from Employee e join Dept d 
on e.deptID = d.deptID
group by e.deptID
order by d.deptname
)
select * from mid
where empcount = (select max(empcount) from mds)



14
select d.deptname, e.empid, e.salary, row_number() over (partition by d.deptname order by e.salary)
from Employee e join Dept d 
on e.deptID = d.deptID
order by d;deptname,e.salary

