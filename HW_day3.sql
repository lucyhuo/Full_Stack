SET STATISTICS IO ON
-- 1. List all cities that have both Employees and Customers.
SELECT DISTINCT e.City
FROM Employees e INNER JOIN Customers c on e.City = c.City


/*
2. List all cities that have Customers but no Employee.
	a. Use sub-query
	b. Do not use sub-query
*/ 
-- answer a 
SELECT DISTINCT c.City
FROM Customers c 
WHERE c.City not in (SELECT DISTINCT e.City FROM Employees e)

-- answer b 
SELECT  DISTINCT c.City
FROM Customers c 
LEFT JOIN Employees e on c.City = e.City
WHERE e.City is null 


-- 3. List all products and their total order quantities throughout all orders.
-- answer a: 2 scans, 13 logical reads, 0 physical reads
SELECT p.ProductName, sum(od.Quantity) as Total
FROM Products p 
LEFT JOIN [Order Details] od on od.ProductID = p.ProductID
GROUP BY p.ProductName

-- answer b: 2 scans, 13 logical reads, 1 physical read
SELECT p.ProductName, pq.Total
FROM Products p 
LEFT JOIN 
(
SELECT od.ProductID, sum(od.Quantity) as Total
FROM [Order Details] od
GROUP BY od.ProductID
) pq on p.ProductID = pq.ProductID


-- 4. List all Customer Cities and total products ordered by that city.
SELECT c.City, count(od.ProductID) as total
FROM Customers c
LEFT JOIN Orders o on c.City = o.ShipCity
LEFT JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY c.city


/*
-- 5. List all Customer Cities that have at least two customers.
Use union
Use sub-query and no union
*/ 
-- answer a: Use union
SELECT c.City, count(DISTINCT c.ContactName) as total
FROM Customers c
GROUP BY c.City
HAVING count(DISTINCT c.ContactName) >= 2

-- answer b: use SUBQUERIES
SELECT *
FROM 
(
SELECT c.City, count(DISTINCT c.ContactName) as total
FROM Customers c
GROUP BY c.City
) cc
WHERE total >= 2 


-- 6. List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City, count(DISTINCT od.ProductID) as total
FROM Customers c
LEFT JOIN Orders o on c.City = o.ShipCity
LEFT JOIN [Order Details] od on o.OrderID = od.OrderID
GROUP BY c.City
HAVING count(DISTINCT od.ProductID) >= 2


-- 7. List all Customers who have ordered products, 
-- but have the ‘ship city’ on the order different from their own customer cities.
SELECT DISTINCT c.ContactName
FROM Customers c 
INNER JOIN Orders o on o.CustomerID = c.CustomerID
WHERE o.ShipCity <> c.City


-- 8. List 5 most popular products, their average price, 
-- and the customer city that ordered most quantity of it.
SELECT t1.ProductID, t1.AveragePrice, t2.ShipCity
FROM 
(
SELECT TOP 5 od.ProductID, avg(od.UnitPrice) as AveragePrice, sum(od.Quantity) as Total
FROM [Order Details] od
GROUP BY od.ProductID
ORDER BY Total DESC -- ORDER BY can be used in derived table only when TOP, OFFSET, FOR XML is specified
) t1
LEFT JOIN 
(
SELECT 
od.ProductID, o.ShipCity, sum(od.Quantity) as TotalPerCity, 
DENSE_RANK() over(PARTITION BY ProductID ORDER BY sum(Quantity) DESC) as rnk
FROM [Order Details] od
INNER JOIN Orders o on od.OrderID = o.OrderID
GROUP BY od.ProductID, o.ShipCity
) t2 on t1.ProductID = t2.ProductID
WHERE t2.rnk = 1

/*
-- 9. List all cities that have never ordered something but we have employees there.
	a. Use sub-query
	b. Do not use sub-query
*/
-- answer a. Use sub-query
SELECT e.City
FROM Employees e 
WHERE e.City not in (SELECT o.ShipCity FROM Orders o)

-- b. Do not use sub-query
SELECT e.City
FROM Employees e 
LEFT JOIN Orders o on e.City = o.ShipCity
WHERE o.ShipCity is null 


-- 10. List one city, if exists, that is the city from where the employee sold most orders 
-- (not the product quantity) is, and also the city of most total quantity of products ordered from. 
-- (tip: join  sub-query)

SELECT TOP 1 e.City, sum(o.Total) as CityTotal
FROM Employees e
LEFT JOIN
(
SELECT o.EmployeeID, count(DISTINCT o.OrderID) as Total
FROM Orders o 
GROUP BY o.EmployeeID
) o on e.EmployeeID = e.EmployeeID
GROUP BY e.City
ORDER BY CityTotal DESC

SELECT TOP 1 o.ShipCity, sum(TotalProduct) as CityTotalProduct
FROM Orders o 
LEFT JOIN 
(
SELECT 
t.OrderID, count(t.ProductID) as TotalProduct
FROM [Order Details] t
GROUP BY t.OrderID
) od on o.OrderID = od.OrderID
GROUP BY o.ShipCity
ORDER BY CityTotalProduct DESC


-- 11. How do you remove the duplicates record of a table?
DELETE T
FROM 
(
SELECT ProductID,
ROW_NUMBER() OVER (PARTITION BY ProductID ORDER BY (SELECT NULL)) rn
FROM Products
) AS T
WHERE rn > 1

-- 12. Sample table to be used for solutions below- 
-- Employee ( empid integer, mgrid integer, deptid integer, salary integer) 
-- Dept (deptid integer, deptname text)
--  Find employees who do not manage anybody.

--DROP TABLE #Employee
CREATE TABLE #Employee (empid int identity, mgrid int, deptid int, salary int)

INSERT INTO #Employee VALUES(null, 1, 3000)
INSERT INTO #Employee VALUES(1, 1, 2000)
INSERT INTO #Employee VALUES(1, 1, 1900)
INSERT INTO #Employee VALUES(2, 1, 1800)


INSERT INTO #Employee VALUES(null, 2, 4000)

INSERT INTO #Employee VALUES(null, 3, 3500)
INSERT INTO #Employee VALUES(5, 3, 3300)
INSERT INTO #Employee VALUES(5, 3, 3000)
INSERT INTO #Employee VALUES(5, 3, 3100)

SELECT * FROM #Employee

CREATE TABLE #Dept (deptid int, deptname varchar(10))
INSERT INTO #Dept VALUES (1, 'Accounting') 
INSERT INTO #Dept VALUES (2, 'IT')
INSERT INTO #Dept VALUES (3, 'DS')

SELECT * FROM #Dept

GO

SELECT DISTINCT empid
FROM #Employee
WHERE empid not in (SELECT DISTINCT mgrid FROM #Employee WHERE mgrid is not null)
-- need to specify where mgrid is not null???

-- 13. Find departments that have maximum number of employees. 
-- (solution should consider scenario having more than 1 departments 
-- that have maximum number of employees). 
-- Result should only have - deptname, count of employees sorted by deptname.

SELECT deptid
FROM 
(
SELECT e.deptid, count(e.empid) as cnt, 
rank() OVER (ORDER BY count(e.empid) DESC) as rnk
FROM #Employee e
GROUP BY e.deptid
) t 
WHERE rnk = 1

-- 14. Find top 3 employees (salary based) in every department. 
-- Result should have deptname, empid, salary sorted by deptname 
-- and then employee with high to low salary.

SELECT d.deptname, empid, salary 
FROM 
(
SELECT deptid, empid, salary,
rank() OVER(PARTITION BY deptid ORDER BY salary DESC) as rk 
FROM #Employee
) t1 
LEFT JOIN #Dept d on t1.deptid = d.deptid 
WHERE t1.rk <= 3
ORDER BY deptname, salary DESC








