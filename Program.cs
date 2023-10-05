using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiskas_Darbelis
{

    internal class Program
    {
        class Turistai
        {
            private int eurai, centai;
            public Turistai(int eurai, int centai)
            {
                this.eurai = eurai;
                this.centai = centai;
            }

            public int ImtiEurus() { return eurai; }
            public int ImtiCentus() { return centai; }
        }

        const int Cn = 100;
        const string CFd = "TextFile1.txt";

        static void Main(string[] args)
        {
            Turistai[] D = new Turistai[Cn];

            int kiekis;
            Skaityti(CFd, D, out kiekis);
            Console.WriteLine("Turistu kiekis: {0}", kiekis);

            Console.WriteLine("Eurai    Centai");
            for (int i = 0; i < kiekis; i++)
            {
                Console.WriteLine("{0} {1,5:d}", D[i].ImtiEurus(), D[i].ImtiCentus());
              
            }

            int a1 = (suma(D, kiekis) / 100);
            int a2 = (suma(D, kiekis) % 100);
            int b1 = vidutiniskai(D, kiekis) / 100;
            int b2 = vidutiniskai(D, kiekis) % 100;
            int c1 = (suma1(D, kiekis) / 100);
            int c2 = (suma1(D, kiekis) % 100);

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Suma: {0} eurai {1} centai ", a1, a2);
            Console.WriteLine("Kiek vidutiniskai vienam nariui: {0} eurai {1} centai ", b1, b2);
            Console.WriteLine("Is viso surinkta bendroms islaidoms suma: {0} eurai  {1} centai ",c1, c2);
        }

        static void Skaityti(string fv, Turistai[] D, out int kiekis)
        {
            int eurai;
            int centai;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                kiekis = int.Parse(line);
                for (int i = 0; i < kiekis; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    eurai = int.Parse(parts[0]);
                    centai = int.Parse(parts[1]);
                    D[i] = new Turistai(eurai, centai);

                }
            }
        }
        static int suma(Turistai[] D, int kiekis)
        {
            int suma = 0;

            for (int i = 0; i < kiekis; i++)
            {
                suma += (D[i].ImtiEurus() * 100) + D[i].ImtiCentus();

            }
            return suma;
        }

        static int suma1(Turistai[] D, int kiekis)
        {
            int vidutinisk = 0;
            for (int i = 0; i < kiekis; i++)
            {
                vidutinisk += ((D[i].ImtiEurus() * 100) / 4 + D[i].ImtiCentus() / 4);
            }
            return vidutinisk;

        }

        static int vidutiniskai(Turistai[] D, int kiekis)
        {
            int suma = 0;
            int vid;
            for (int i = 0; i < kiekis; i++)
            {
                suma += (D[i].ImtiEurus() * 100) + D[i].ImtiCentus();
            }
            vid = suma / kiekis;
            return vid;
        }

    }

}
