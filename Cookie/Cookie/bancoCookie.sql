create database cookie;

use cookie;

create table cookie(
	id int primary key auto_increment,
	sabor varchar(60),
	valor decimal(10,2)
);

select * from cookie