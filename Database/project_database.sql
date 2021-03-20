CREATE DATABASE IF NOT EXISTS softuniprojectdb;
use softuniprojectdb;

CREATE TABLE IF NOT EXISTS companies ( 
id INT AUTO_INCREMENT primary key,
name varchar(45) NOT NULL,
rate INT NOT NULL
);

CREATE TABLE IF NOT EXISTS workers_profile ( 
id INT AUTO_INCREMENT primary key,
username varchar(45) NOT NULL,
password varchar(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS person_info (
id INT auto_increment primary key,
first_name varchar(60) NOT NULL,
last_name varchar(60),
money DECIMAL(15,2) NOT NULL DEFAULT 0,
company_id INT,
work_hours INT,
FOREIGN KEY (company_id) REFERENCES companies(id),
FOREIGN KEY (id) REFERENCES workers_profile(id) 
);



INSERT INTO workers_profile (id, username, password) VALUES
(1, 'Unbanshee','a8GMvIsMkFOTfDZ/ciFkhcS2rfI='),
(2, 'Laserpent','4ZQR0GzS6WOVr10XxXh3imn2wvI='),
(3, 'Maybeast','K7O251GdsyeKg54HeoSQ5ak3goc='),
(4, 'Emutant','fH8AHU9C4Adz6Er7PzU/wnH1GrQ='),
(5, 'OpinionPuggle','lACuKESOE2QXTd4mmyzOG8qdfug=');

INSERT INTO companies(id, name, rate) VALUES 
(1, 'Sealord', 6),
(2, 'Feil Group', 9),
(3, 'Halvorson LLC', 3),
(4, 'Grant-Howell', 9),
(5, 'Gislason', 2);

INSERT INTO person_info (id, first_name, last_name, money, company_id, work_hours) VALUES
(1, 'Ferne', 'Clive', 1726.21, 1, null),
(2, 'Yash', 'Ballard', 578.03, 4, 28),
(3, 'Tye', 'Smockers', 8374.45, 3, 37),
(4, 'Brendan', 'Decker', 5374.39, 2, 107),
(5, 'Blake', 'Bowers', 9152.35, 5, 118);


