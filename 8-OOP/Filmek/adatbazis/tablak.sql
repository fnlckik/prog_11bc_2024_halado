CREATE DATABASE televizio;
USE televizio;

CREATE TABLE filmek (
    id INT PRIMARY KEY AUTO_INCREMENT,
    cim VARCHAR(255),
    ev INT,
    mufaj VARCHAR(255),
    imdb FLOAT,
    nezok INT
);
