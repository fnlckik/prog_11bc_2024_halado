# 1. Függvények, eljárások

## Feladatok

1. Hozz létre egy függvényt, amely kiszámolja egy téglalap kerületét a két oldalából!

    Példa:
    ```cs
    Kerulet(3, 5) == 16
    Kerulet(1.25, 4) == 10.5
    ```

2. A `ParosE(n)` függvény döntse el, hogy a paraméterként kapott `n` szám páros vagy páratlan!

    Példa:
    ```cs
    ParosE(5) == false
    ParosE(162) == true
    ```

3. Írj függvényt, amely megadja egy egész számokat tartalmazó tömb elmeinek maximumát!
    
    Példa:
    ``` cs
    Max({4, 7, -3, 12, 7, 14, -1}) == 14
    ```

---

4. Készíts `Kiir(s)` néven eljárást, amely paraméterként kap egy szöveget, majd sorsol egy random számot 5 és 20 között, és a szöveget megfelelő mennyiségű alkalommal jeleníti meg a konzolon!

5. Írj `Beolvas(n)` nevű eljárást, ami beolvassa `n` egész típusú változó értékét, majd eltárolja azt! A fő program ezután kiírja a beolvasott érték négyzetgyökét a konzolra!
   
   **Vigyázat:** negatív számok négyzetgyöke nem valós!

6. A `Novel(t)` eljárás a `t` tömb minden elemét növelje meg egyel! Programozd le!

7. A `Duplaz(a)` eljárás változtassa meg az `a` paraméter értékét a kétszeresére!

---

8. Írj függvényt, amely egy `p` pozitív egész számról eldönti, hogy prímszám-e! Használd fel a függvényt arra, hogy egy számokat tartalmazó tömbből kiválogasd a prímszámokat!

    Példa:
    ``` cs
    Primszamok({7, 23, 6, 42, 73, 2, 3, 9, 1, 5}) == {7, 23, 73, 2, 3, 5}
    ```

9. Adott egy egész számokat tartalmazó tömb. Készíts függvényt, amely megadja az első olyan elemét, amelynek legalább 20 osztója van!

    Példa:
    ```cs
    SokOsztos({6, 1001, 24, 360, 75}) == 360
    ```