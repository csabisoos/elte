using System;
using System.Collections.Generic;
namespace nagy_valtozasu_telepulesek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sortomb = Console.ReadLine().Split(' ');
            int n = int.Parse(sortomb[0]);
            int m = int.Parse(sortomb[1]);
            int[,] homerseklet = new int[n,m];

            for (int i = 0; i < n; i++)
            {
                sortomb = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    homerseklet[i, j] = int.Parse(sortomb[j]);
                }
            }
            int db=0;
            List<int> sorszamok = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int j = 1;
                while (j<m && !(homerseklet[i, j - 1] - homerseklet[i,j]>=10 || homerseklet[i, j] - homerseklet[i,j-1]>=10))
                {
                    j += 1;
                }
                if (j<m)
                {
                    db += 1;
                    sorszamok.Add(i+1);
                }
            }
            Console.Write($"{db} ");
            Console.Write(String.Join(' ', sorszamok));
        }
    }
}
