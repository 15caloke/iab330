create table boxes(
id int(11) NOT NULL auto_increment PRIMARY KEY, 
userId int(11), index usr_in (userId), foreign KEY (userId) REFERENCES user(id) on delete cascade, 
number int(5), 
category varchar(60), 
qrCode varchar(200))
