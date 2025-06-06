﻿using MySqlConnector;
using System;

namespace Filmek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // cim, ev, mufaj, imdb, nezok (akik értékelték imdb-n)
            Film f1 = new Film("Wonder Woman", 2017, "akcio", 4.4, 30);
            //Film f2 = new Film("Vasember", 2008, "akcio", 7.6, 50);
            Film f2 = new Film("Vasember;2008;akcio;7,6;50");

            //Console.WriteLine(f2.Mufaj); // itt használjuk f2-t utoljára
            // Garbage collector (szemétgyűjtő)
            Console.WriteLine($"{f1.Cim}: {f1.Ev}"); // Wonder Woman: 2017 BC

            f1.Mufaj = "fantasy";
            f1.Mufaj = "romantikus";

            f1.Ertekel(10);
            f1.Ertekel(-5);
            //Console.WriteLine(f1.Mufaj);
            Console.WriteLine(f1);
            Console.WriteLine(f2);
            Console.WriteLine($"{f2.Cim} < {f1.Cim} :: {f2.KorabbiE(f1)}");
            Console.Clear();

            // ------------------------------------
            Televizio tv = new Televizio("filmek.txt");
            //tv.Filmek[0] = null;
            //Console.WriteLine(tv.Filmek[0]);
            Film legregebbi = tv.Legregebbi();
            Console.WriteLine(legregebbi);
            tv.Kiir("teletex.txt", 10);

            // Számoljuk meg, hogy melyik műfaj hányszor fordul elő?
            Console.WriteLine("Műfajok gyakorisága:");
            Console.WriteLine(tv.Darabok);
            // akció: 3 db
            // horror: 2 db

            tv.AdatGeneralas();

            Console.Clear();
            // Nem része a beadandónak! Csak megmutattam, mert kíváncsi volt a csoport!
            DbQuery();
            Console.WriteLine("Vége!");
        }

        private static void DbQuery()
        {
            Console.Write("Melyik évnél későbbi filmek érdekelnek? ");
            string connectionString = "Server=localhost;Database=televizio;User ID=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM filmek WHERE cim = @cim;";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cim", Console.ReadLine());
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Feltételezve, hogy a Users tábla két oszlopot tartalmaz: Id és Name
                            Console.WriteLine($"Cím: {reader["cim"]}, Év: {reader["ev"]}");
                        }
                    }
                }
            }
        }
    }
}
