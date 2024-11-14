using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hajok_a_kikotoben_biro
{
    internal class Program
    {

        /** /
        static void beolvas(int n, int m, List<int> lista)
        {
            string[] sortomb = Console.ReadLine().Split(' ');
            //int.TryParse(sortomb[0], out n);
            n = int.Parse(sortomb[0]);
            if(1<=n && n<=1000)
            {
                //int.TryParse(sortomb[1], out m);
                m = int.Parse(sortomb[1]);
                if(1<=m && m<=1000)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        string nap = Console.ReadLine();
                        if(1<=int.Parse(nap) && int.Parse(nap) <= m)
                        {
                            lista.Add(int.Parse(nap));
                        }
                        else
                        {
                            Console.Error.WriteLine($"Hibas bemenet!");
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine($"Hibas bemenet!");
                }
            }
            else
            {
                Console.Error.WriteLine($"Hibas bemenet!");
            }
        }
        /**/

        static int darab(List<int> hol, int mit)
        {
            int db = 0;
            for (int i = 0; i < hol.Count(); i++)
            {
                if (hol[i] == mit)
                {
                    ++db;
                }
            }
            return db;
        }

        static List<int> masol(List<int> mibol, int m)
        {
            List<int> mibe = new List<int>();
            for (int i = 0; i < m; ++i)
            {
                mibe.Add(darab(mibol, i + 1));
            }
            return mibe;
        }

        static int kettes(List<int> lista)
        {
            for(int i=1;i<lista.Count()-1;++i)
            {
                if (lista[i] != 0 && lista[i-1] == 0 && lista[i+1] == 0)
                {
                    return ++i;
                }
            }
            return -1;
        }

        static int harmas(List<int> lista)
        {
            int max = 0;
            int szamolas = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i] == 0)
                {
                    ++szamolas;
                }
                else
                {
                    szamolas = 0;
                }
                if (szamolas>max)
                {
                    max = szamolas;
                }   
            }
            return max;
        }

        static int negyes(List<int> lista)
        {
            int maxi = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i] > lista[maxi])
                    maxi = i;
            }
            return maxi+1;
        }

        static (int,int) otos(List<int> lista)
        {
            int hossz = 0;
            int index = 0;
            int eindex = 0;
            int maxhossz = 0;

            while (index < lista.Count())
            {
                if (lista[index] == 0)
                {
                    if (hossz > maxhossz)
                    {
                        maxhossz = hossz;
                        eindex = index - maxhossz - 1;
                    }
                    hossz = 0;
                }
                else
                {
                    hossz++;
                }
                index++;
            }


            return (eindex, eindex+maxhossz);
        }

        static void Main(string[] args)
        {
            #region beolvasas
            int n = 0;
            int m = 0;
            bool jo = false;
            List<int> erkezes = new List<int>();
            do
            {
                erkezes = new List<int>();
                string[] sortomb = Console.ReadLine().Split(' ');
                int.TryParse(sortomb[0], out n);
                if (1 <= n && n <= 1000)
                {
                    jo = true;
                    int.TryParse(sortomb[1], out m);
                    if (1 <= m && m <= 1000)
                    {
                        jo = true;
                        for (int i = 0; i < n; ++i)
                        {
                            string nap = Console.ReadLine();
                            if (1 <= int.Parse(nap) && int.Parse(nap) <= m)
                            {
                                jo = true;
                                erkezes.Add(int.Parse(nap));
                            } else {
                                jo = false;
                                --i;
                                Console.Error.WriteLine($"Hibas bemenet!");
                            }
                        }
                    } else {
                        jo = false;
                        Console.Error.WriteLine($"Hibas bemenet!");
                    }
                } else {
                    jo = false;
                    Console.Error.WriteLine($"Hibas bemenet!");
                }
            } while (!jo);
            #endregion

            //beolvas(n,m,erkezes);
            #region 1.
            List<int> napok = masol(erkezes, m);
            /**/
            for (int i = 0; i < napok.Count; i++)
            {
                Console.Error.WriteLine($"{napok[i]} ");
            }
            /**/
            int db = darab(napok, 0);
            #endregion

            Console.WriteLine($"#\n{db}");
            Console.WriteLine($"#\n{kettes(napok)}");
            Console.WriteLine($"#\n{harmas(napok)}");
            Console.WriteLine($"#\n{negyes(napok)}");
            Console.WriteLine($"#\n{otos(napok)}");

        }
    }
}