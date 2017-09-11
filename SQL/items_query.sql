create table items(boxId int, index itm_ind (boxId),
foreign key (boxId) references boxes(id) on delete cascade,
name varchar(60), description varchar(200),
boxNum int references boxes(num) on delete cascade, imagePath varchar(1024)
);
