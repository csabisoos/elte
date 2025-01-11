using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using magas_szintű_mintamegvalósítások;

namespace nagy_valtozasu_telepulesek_magas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] homerseklet;
            int db;
            int[] sorszamok;

            homerseklet = beolvas();
            int n = homerseklet.GetLength(0);
            int m = homerseklet.GetLength(1);

            sorszamok = Mintak.Kivalogat(0, n - 1, i => Mintak.Van(1, m - 1, j => (Math.Abs(homerseklet[i, j - 1] - homerseklet[i, j]) >= 10)), i => i + 1);
            db = sorszamok.Length;

            kiir(db, sorszamok);
        }
        static void kiir(int db, int[] sorszamok)
        {
            if (Console.IsOutputRedirected)
            {
                Console.Write($"{db} ");
                Console.Write(String.Join(' ', sorszamok));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (db == 0)
                {
                    Console.WriteLine("Nincs a feltételnek megfelelő település!");
                }
                else
                {
                    Console.WriteLine("{0} darab feltételnek megfelelő település is van, sorszámaik: ", db);
                    Console.WriteLine(String.Join(", ", sorszamok));
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write("Kérem, nyomjon ENTER-t a folytatáshoz!");
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        static int[,] beolvas()
        {
            if (Console.IsInputRedirected)
            {
                return beolvas_biro();
            }
            else
            {
                return beolvas_kezi();
            }
        }
        static int[,] beolvas_biro()
        {
            string[] sortomb = Console.ReadLine().Split(' ');
            int n = int.Parse(sortomb[0]);
            int m = int.Parse(sortomb[1]);
            int[,] homerseklet = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                sortomb = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    homerseklet[i, j] = int.Parse(sortomb[j]);
                }
            }
            return homerseklet;
        }
        static int[,] beolvas_kezi()
        {
            int n, m;
            bool jo;
            do
            {
                Console.ResetColor();
                Console.Write("Települések száma = ");
                jo = int.TryParse(Console.ReadLine(), out n) && 1 <= n && n <= 1000;
                if (!jo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A szám nem megfelelő (1<=N<=1000)!");
                }
            } while (!jo);
            do
            {
                Console.ResetColor();
                Console.Write("Napok száma = ");
                jo = int.TryParse(Console.ReadLine(), out m) && 1 <= m && m <= 1000;
                if (!jo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A szám nem megfelelő (1<=N<=1000)!");
                }
            } while (!jo);

            int[,] homerseklet = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    do
                    {
                        Console.ResetColor();
                        Console.Write($"{i + 1}. település {j + 1}. hömérséklet értéke = ");
                        jo = int.TryParse(Console.ReadLine(), out homerseklet[i, j]) && -50 <= homerseklet[i, j] && homerseklet[i, j] <= 50;
                        if (!jo)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("A szám nem megfelelő (-50<=H<=50)");
                        }
                    } while (!jo);
                }
            }
            return homerseklet;
        }
    }
}

