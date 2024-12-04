using System;
namespace uj_orseg_kuldese_a_kinai_nagy_falra
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sortomb = Console.ReadLine().Split(' ');
            int n = int.Parse(sortomb[0]);
            int m = int.Parse(sortomb[1]);
            int[] lista = new int[m];
            for (int i = 0; i < m; i++)
            {
                lista[i] = (int.Parse(Console.ReadLine()));
            }
            int[] orsegek = new int[n];
            for (int i = 0; i < m; i++)
            {
                orsegek[lista[i]-1] = 1;
            }
        }
    }
}