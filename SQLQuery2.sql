create database Products
use Products
create table Product
(
Product_name varchar(100),
Quantity int,
Sale_Price money,
Total_Price money
);
select *from Product

insert into Product values('volleyball',10 ,20,200) 
select Product_name from Product