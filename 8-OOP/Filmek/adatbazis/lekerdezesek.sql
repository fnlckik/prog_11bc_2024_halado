-- Választó lekérdezések (select)
-- 1. Milyen műfajok vannak?
SELECT DISTINCT mufaj FROM filmek;

-- 2. Melyik a legrégebbi akció film?
SELECT *
FROM filmek
WHERE mufaj = "akcio"
ORDER BY ev
LIMIT 1;

-- 3. Melyik a 10 legjobb film IMDB pontszám szerint?
SELECT *
FROM filmek
ORDER BY imdb DESC
LIMIT 10;

-- Csoportosító lekérdezések (group by)
-- 4. Hány darab van az egyes műfajokból?
-- Aggregátor függvény: összesítő függvények
-- COUNT, SUM, AVG, MIN, MAX
-- COUNT(*): Hány ilyen rekord van?
SELECT mufaj, COUNT(*) AS "darab", MAX(imdb) AS "legjobb_imdb"
FROM filmek
GROUP BY mufaj;

-- SQL záradékok:
-- 5 SELECT
-- 1 FROM
-- 2 WHERE
-- 3 GROUP BY
-- 4 HAVING
-- 6 ORDER BY
-- 7 LIMIT

-- 5. Mennyi az átlagos IMDB pontszám műfajonként?
-- Csak azokat jelenítsük meg, amelyek átlaga 5.5 feletti
SELECT mufaj, ROUND(AVG(imdb), 2) AS atlag
FROM filmek
GROUP BY mufaj
HAVING atlag > 5.5;
