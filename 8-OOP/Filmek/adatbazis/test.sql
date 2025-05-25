-- A sötét lovag;2008;akcio;8,0;25
-- TRUNCATE ~ DELETE, de az AUTO_INCREMENT PRIMARY KEY-t visszaállítja a kezdő értékre
TRUNCATE filmek;

INSERT INTO filmek (cim, ev, mufaj, imdb, nezok)
VALUES
("A sötét lovag", 2008, "akcio", 8.0, 25),
("A múmia", 1999, "kaland", 6.2, 70);