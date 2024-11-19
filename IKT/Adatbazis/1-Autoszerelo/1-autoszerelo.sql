-- F1
-- Futtatás: CTRL + Enter
CREATE DATABASE IF NOT EXISTS Autoszerelo;
USE Autoszerelo;

-- F2
CREATE TABLE IF NOT EXISTS Ugyfel (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nev VARCHAR(50),
    email VARCHAR(100),
    telefon CHAR(11),
    aktiv BOOLEAN
);
