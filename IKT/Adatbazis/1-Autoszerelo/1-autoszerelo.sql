-- F1
-- Futtatás: CTRL + Enter
DROP DATABASE IF EXISTS Autoszerelo;
CREATE DATABASE Autoszerelo;
USE Autoszerelo;

-- F2
DROP TABLE IF EXISTS Ugyfel;
CREATE TABLE Ugyfel (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nev VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    telefon CHAR(11),
    aktiv BOOLEAN DEFAULT TRUE
);

-- Kitekintés:
/*
INSERT INTO Ugyfel (nev, email, telefon, aktiv)
VALUES
("Kis Pista", "kis.pista@gmail.com", "06202235123", TRUE),
("Fekete Laci", NULL, NULL, FALSE);
*/

-- F3
-- datum: Mikor adták le az autót javításra?
-- TEXT: jelentősen változó hosszú szöveg
-- Összetett kulcs leírása: UNIQUE (ugyfel_id, rendszam, datum)
DROP TABLE IF EXISTS Javitas;
CREATE TABLE Javitas (
    id INT PRIMARY KEY AUTO_INCREMENT,
    ugyfel_id INT NOT NULL,
    rendszam CHAR(6) NOT NULL,
    datum DATE NOT NULL,
    koltseg INT,
    leiras TEXT,
    FOREIGN KEY (ugyfel_id) REFERENCES Ugyfel(id),
    CONSTRAINT UQ_Javitas_ugyfelId_rendszam_datum UNIQUE (ugyfel_id, rendszam, datum)
);

-- F4
INSERT INTO Ugyfel (nev, email, telefon, aktiv)
VALUES
('Kovács Péter', 'kovacs.peter@example.com', '36201234567', TRUE),
('Nagy Anna', 'nagy.anna@example.com', '36301122334', TRUE),
('Szabó László', 'szabo.laszlo@example.com', NULL, TRUE),
('Tóth Mária', 'toth.maria@example.com', NULL, FALSE),
('Varga István', 'varga.istvan@example.com', '36201111222', TRUE);

