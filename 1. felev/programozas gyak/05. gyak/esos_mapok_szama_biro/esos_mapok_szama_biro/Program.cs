using System;
namespace esos_mapok_szama_biro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            //Console.Error.Write("n: ");
            int.TryParse(Console.ReadLine(), out n);
            int[] esos = new int[n];
            for (int i = 0; i < n; i++)
            { 
                int.TryParse(Console.ReadLine(), out esos[i]);
            }
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (esos[i] != 0)
                {
                    db++;
                }
            }
            Console.WriteLine(db);

        }
    }
}
