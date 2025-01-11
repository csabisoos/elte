using System;
using System.Collections.Generic;
namespace nagy_valtozasu_telepulesek
{
    class Program
    {
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
                jo = int.TryParse(Console.ReadLine(), out n) && 1<=n && n<=1000;
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

            int[,] homerseklet = new int[n,m];
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

        static void kiir(int db, List<int> sorszamok)
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
        static (int db, List<int> sorszamok) megold(int[,] homerseklet)
        {
            int db = 0;
            List<int> sorszamok = new List<int>();
            for (int i = 0; i < homerseklet.GetLength(0); i++)
            {
                int j = 1;
                while (j < homerseklet.GetLength(1) && Math.Abs(homerseklet[i, j - 1] - homerseklet[i,j])<10)
                {
                    j += 1;
                }
                if (j < homerseklet.GetLength(1))
                {
                    db += 1;
                    sorszamok.Add(i + 1);
                }
            }
            return (db, sorszamok);
        }
        static void Main(string[] args)
        {
            int[,] homerseklet;
            int db = 0;
            List<int> sorszamok = new List<int>();

            homerseklet = beolvas();

            (db, sorszamok) = megold(homerseklet);

            kiir(db, sorszamok);
        }
    }
}
