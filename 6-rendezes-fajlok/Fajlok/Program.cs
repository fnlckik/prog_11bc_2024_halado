using System;
using System.Collections.Generic;
using System.IO;

namespace Fajlok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> kedvencek = new Dictionary<string, int>();
            Olvas(kedvencek);
        }

        static void Olvas(Dictionary<string, int> kedvencek)
        {
            //StreamReader reader = new StreamReader("../../primek.txt");
            StreamReader reader = new StreamReader("primek.txt");
            reader.Close();
        }
    }
}
