drop database if exists kanstov;
create database if not exists kanstov;
USE `kanstov` ;


CREATE TABLE IF NOT EXISTS `category_tovar` (
  `ID_Category_tovara` INT primary key auto_increment,
  `Category_tovar` varchar(255) );

CREATE TABLE IF NOT EXISTS `postavshik` (
  `ID_Postavshika` INT primary key auto_increment,
  `Postavshik` varchar(255));

CREATE TABLE IF NOT EXISTS `proizvoditel` (
  `ID_Proizvoditela` INT primary key auto_increment,
  `Proizvoditel` varchar(255));


CREATE TABLE IF NOT EXISTS `tovar` (
  `Id_tovar` int primary key auto_increment,
  `Articul` varchar(255),
  `Naimenovanie` varchar(255),
  `Edinica_izmerenia` varchar(255),
  `Price` decimal(10,2),
  `Size_max_vozmog_sale` int,
  `ID_Proizvoditela` INT ,
  `ID_Postavshika` INT ,
  `ID_Category_tovara` INT,
  `Deistvyushay_sale` int,
  `Kolvo_na_sklade` INT ,
  `Opisanie` TEXT,
  `Picture` TEXT,
  foreign key (ID_Category_tovara) references category_tovar(ID_Category_tovara),
   foreign key (ID_Proizvoditela) references proizvoditel(ID_Proizvoditela),
   foreign key (ID_Postavshika) references postavshik(ID_Postavshika));
   


select * from Tovar