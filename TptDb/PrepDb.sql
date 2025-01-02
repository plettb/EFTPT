delete from Sales
delete from Sellers
delete from Buyers
delete from Contacts

set identity_insert Contacts on;
insert into Contacts (Id, Name) values (7221, 'Jane Doe');
insert into Contacts (Id, Name) values (7113, 'Jow Blow');
set identity_insert Contacts off;

insert into Buyers (Id) values (7221)
insert into Buyers (Id) values (7113)

insert into Sellers (Id, Inventory) values (7113, 24);
insert into Sellers (Id, Inventory) values (7221, 23);
