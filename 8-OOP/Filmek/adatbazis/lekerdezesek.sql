-- Választó lekérdezések (SELECT)
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

-- Csoportosító lekérdezések (GROUP BY)
-- 4. Hány darab van az egyes műfajokból?
-- Aggregátor függvény: összesítő függvények
-- Pl.: COUNT, SUM, AVG, MIN, MAX
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

-- Frissító lekérdezés (UPDATE)
-- 6. Az összes 2000 előtti film értékelése 0.5 ponttal emelkedik (ha lehetséges)
UPDATE filmek
SET imdb = imdb + 0.5
WHERE ev < 2000 AND imdb <= 9.5;

-- 7. Töröljük azokat a filmeket, amelyek címe tartalmaz ':' karaktert!
DELETE FROM filmek
WHERE cim LIKE "%:%";
