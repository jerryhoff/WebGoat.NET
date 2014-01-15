.separator "|"

DELETE FROM Customers;
DELETE FROM CustomerLogin;
DELETE FROM SecurityQuestions;
DELETE FROM Employees;
DELETE FROM Offices;
DELETE FROM OrderDetails;
DELETE FROM Orders;
DELETE FROM Payments;
DELETE FROM Products;
DELETE FROM Categories;
DELETE FROM Comments;

.import DB_Scripts/datafiles/customers.txt Customers
.import DB_Scripts/datafiles/customerlogin.txt CustomerLogin
.import DB_Scripts/datafiles/securityquestions.txt SecurityQuestions
.import DB_Scripts/datafiles/employees.txt Employees
.import DB_Scripts/datafiles/offices.txt Offices
.import DB_Scripts/datafiles/orderdetails.txt OrderDetails
.import DB_Scripts/datafiles/orders.txt Orders
.import DB_Scripts/datafiles/payments.txt Payments
.import DB_Scripts/datafiles/categories.txt Categories
.import DB_Scripts/datafiles/products.txt Products
