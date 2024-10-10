using System;

namespace nem_volt_kapas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int n;
            n = int.Parse(Console.ReadLine());
            int[] napok = new int[n];            
            for (int i = 0; i < napok.Length; ++i)            
                napok[i] = int.Parse(Console.ReadLine());
            
            while(x < n && !(napok[x] == 0))            
                ++x;
            
            if (x < n)            
                Console.WriteLine(x + 1);            
            else             
                Console.WriteLine(-1);            

        }
    }
}
