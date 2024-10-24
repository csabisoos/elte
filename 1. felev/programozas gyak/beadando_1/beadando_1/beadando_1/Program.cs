/** /
Név: Soós Csaba
Neptun kód: AZXX1Z
Email cím: azxx1z@inf.elte.hu
           sooscsaba@student.elte.hu
/**/
using System;
namespace beadando_1
{
    class Program
    {
        struct Varos
        {
            public int tav;
            public int ar;
        };
        static void Main(string[] args)
        {
            int n = 0;
            int.TryParse(Console.ReadLine(), out n);
            Varos[] varosok = new Varos[n];
            string sor;
            int maxtav;
            int minar;

            for (int i = 0; i < n; i++)
            {
                sor = Console.ReadLine();
                int.TryParse(sor.Split(' ')[0], out varosok[i].tav);
                int.TryParse(sor.Split(' ')[1], out varosok[i].ar);
            }

            maxtav = varosok[0].tav;
            minar = varosok[0].ar;

            for (int i = 1; i < n; i++)
            {
                if (maxtav < varosok[i].tav)
                {
                    maxtav = varosok[i].tav;
                    minar = varosok[i].ar;
                }
                else if (maxtav == varosok[i].tav && minar > varosok[i].ar)
                {
                    minar = varosok[i].ar;
                }
            }

            Console.WriteLine(minar);
        }
    }
}