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
    koltseg INT DEFAULT 12000,
    leiras TEXT,
    FOREIGN KEY (ugyfel_id) REFERENCES Ugyfel(id),
    CONSTRAINT UQ_Javitas_ugyfelId_rendszam_datum UNIQUE (ugyfel_id, rendszam, datum),
    CONSTRAINT CHK_Javitas_koltseg CHECK (koltseg BETWEEN 12000 AND 500000)
);
-- Másképp:
-- CHECK (12000 <= koltseg AND koltseg <= 500000)
-- CHECK (12000 <= koltseg && koltseg <= 500000)
-- CHECK (koltseg BETWEEN 12000 AND 500000)
-- 12000 és 500000 közötti (határokat is beleértve)

-- Példa:
/*
INSERT INTO javitas (ugyfel_id, rendszam, datum, koltseg)
VALUES (1, "HKG141", CURRENT_DATE, 42000);

INSERT INTO javitas (ugyfel_id, rendszam, datum, koltseg)
VALUES (2, "HKG141", CURDATE(), 42000);
*/

-- F4
INSERT INTO Ugyfel (nev, email, telefon, aktiv)
VALUES
('Kovács Péter', 'kovacs.peter@example.com', '36201234567', TRUE),
('Nagy Anna', 'nagy.anna@example.com', '36301122334', TRUE),
('Szabó László', 'szabo.laszlo@example.com', NULL, TRUE),
('Tóth Mária', 'toth.maria@example.com', NULL, FALSE),
('Varga István', 'varga.istvan@example.com', '36201111222', TRUE);

INSERT INTO Javitas (ugyfel_id, rendszam, datum, koltseg, leiras)
VALUES 
(3, 'LMN123', '2024-04-10', 30000, 'Hűtőrendszer javítása'),
(1, 'DEF456', '2024-03-20', 20000, 'Szélvédő javítás'),
(4, 'QRS456', '2024-05-12', 12000, 'Olajcsere'),
(2, 'XYZ789', '2024-01-20', 80000, 'Motorhiba javítása'),
(5, 'TUV789', '2024-03-05', 500000, 'Komplex felújítás'),
(1, 'ABC123', '2024-02-15', 15000, 'Téli gumik felszerelése'),
(4, 'QRS456', '2024-06-01', NULL, 'Kormánymű javítása'),
(1, 'ABC123', '2024-01-10', 45000, 'Olajcsere és szűrők cseréje'),
(2, 'XYZ789', '2024-02-05', 20000, 'Kipufogó csere'),
(5, 'TUV789', '2024-02-25', 250000, 'Teljes karosszéria lakatolás'),
(3, 'LMN123', '2024-03-15', NULL, 'Akkumulátor csere'),
(1, 'DEF456', '2024-03-01', NULL, 'Fékek teljes cseréje'),
(2, 'XYZ789', '2024-04-15', 15000, 'Gumiabroncs javítás');