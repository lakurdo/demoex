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
   
CREATE TABLE roles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role_id INT,
    FOREIGN KEY (role_id) REFERENCES roles(id)
);

-- Вставка ролей
INSERT INTO roles (name) VALUES ('Администратор'), ('Клиент');

-- Вставка пользователей (пароли условные)
INSERT INTO users (username, password_hash, role_id)
VALUES 
('лякурдо_блядэ', 'лякурдо_блядэ', 1),
('lak', 'lak', 2)

select * from users