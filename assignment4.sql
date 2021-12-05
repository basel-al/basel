--1. A view is a virtual table. It helps security by making parts of tables accessible to users and also helps admins put together complex queries that are readable.
--2. yes if the permissions allow
--3. A saved oject that contains one ot more SQL statements. It is beneficial to use because it limits direct access to statements and improves performance due to database optimizing the access plan used in the procedure.
--4. A view is a virtual table and a stored procedure is a set of instructions
--5. Stored Procedurs do not have to return values. Functions can only have input parameters. Functions can be called in Procedures.
--6. yes
--7. no, because stored procedures are not guranteed to return a valid column (or anything at all) that fits the SELECT statement
--8. Stored procedures that are executed when a specific event happens. DDL, DML, and Logon are trigger types.
--9. Triggers run stored procedures automatically when an event happens. They cannot take inputs, use transaction statements or return values unlike stored procedures.

use Northwind

--1.
Create view view_product_order_alchaar as
select p.ProductName,sum(od.Quantity) as [Ordered Quantity]
from [Order Details] od join Products p on od.ProductID = p.ProductID
group by p.ProductName

drop view view_product_order_alchaar 

--2.
create procedure sp_product_order_quantity_alchaar @ProductID int as
begin
select sum(Quantity)
from [Order Details]
where ProductID = @ProductID
group by [Order Details].ProductID
end

--3.
create procedure sp_product_order_city_alchaar @ProductName nvarchar(40) as
begin
select top 5 sum(od.Quantity) as [Ordered Quantity], ShipCity
from [Order Details] od join Orders o on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
where ProductName = @ProductName
group by ShipCity
order by [Ordered Quantity] desc
end

--4
select * from city_alchaar
select * from people_alchaar

create table city_alchaar(Id int, City nvarchar(40))
insert into city_alchaar(Id, City) values (1, 'Seattle')
insert into city_alchaar(Id, City) values (2, 'Green Bay')

create table people_alchaar(id int, Name nvarchar(40), City int)
insert into people_alchaar(id, Name, City) values (1, 'Aaron Rogers', 2)
insert into people_alchaar(id, Name, City) values (2, 'Russell Wilson', 1)
insert into people_alchaar(id, Name, City) values (3, 'Jody Nelson', 2)

delete from city_alchaar where City='Seattle'
insert into city_alchaar(Id, City) values (1, 'Madison')

Create view Packers_alchaar as
select pa.Name from people_alchaar pa join city_alchaar ca on pa.City = ca.City
where ca.City = 'Green Bay'

select * from Packers_alchaar
drop table city_alchaar
drop table people_alchaar
drop view Packers_alchaar

--5.
create procedure sp_birthday_employees_alchaar as
begin
create table birthday_employees_alchaar(EmployeeID int, LastName nvarchar(20), FirstName nvarchar(10), BirthDate datetime )

select EmployeeID, LastName, FirstName, BirthDate into birthday_employees_alchaar
from Employees
where month(birthDate) = 2
end

exec sp_birthday_employees_alchaar

drop table birthday_employees_alchaar 

select *
from Employees
where month(birthDate) = 2
end

--6.
--UNION both tables and ensure your output is the same size as both tables