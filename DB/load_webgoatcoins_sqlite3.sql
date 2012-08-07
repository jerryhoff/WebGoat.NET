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

.import datafiles/customers.txt Customers
.import datafiles/customerlogin.txt CustomerLogin
.import datafiles/securityquestions.txt SecurityQuestions
.import datafiles/employees.txt Employees
.import datafiles/offices.txt Offices
.import datafiles/orderdetails.txt OrderDetails
.import datafiles/orders.txt Orders
.import datafiles/payments.txt Payments
.import datafiles/categories.txt Categories
.import datafiles/products.txt Products
