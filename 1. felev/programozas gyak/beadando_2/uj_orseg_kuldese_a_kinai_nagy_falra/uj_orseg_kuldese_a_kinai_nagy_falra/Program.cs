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
                lista[i] = (int.Parse(Console.ReadLine()));

            int[] orsegek = new int[n];
            for (int i = 0; i < m; i++)
                orsegek[lista[i]-1] = 1;

            int[] orsegszamok = new int[m];
            int j = 0;
            for (int i = 0; i < n; ++i){
                if (orsegek[i] != 0){
                    orsegszamok[j] = i+1;
                    ++j;
                }
            }

            int[] kul = new int[m+1];
            kul[0] = orsegszamok[0] - 1;
            for (int i = 1; i < m; i++)
                kul[i] = orsegszamok[i] - orsegszamok[i - 1] - 1;
            if (orsegszamok[orsegszamok.Length - 1] != n)
            {
                kul[kul.Length - 1] = n - orsegszamok[orsegszamok.Length-1];
            }

            int db = 0;
            for (int i = 0; i < m+1; i++){
                if (kul[i]>1){
                    db = db + 1;
                }
            }

            int[] hiany = new int[db];
            j = 0;
            for (int i = 0; i < m+1; i++){
                if (kul[i]>1){
                    hiany[j] = kul[i];
                    ++j;
                }
            }

            int uj = 0;
            for (int i = 0; i < db; i++){
                uj = uj + hiany[i] / 2;
            }
            
            Console.WriteLine(uj);
        }
    }
}
/*
15 9
6
3
12
11
4
5
8
15
14
*/