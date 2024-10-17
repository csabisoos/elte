namespace magasabbdiak
{
    internal class Program
    {
        struct Tdiak
        {
            public string nev;
            public int mag;
        };
        static void Main(string[] args)
        {
            /**/
            int n = 3;          
            int db = 0;
            List<Tdiak> diakok = new List<Tdiak>();
            List<string> nevek = new List<string>();
            /** /
            for (int i = 0; i < n; i++)
            {               
                Tdiak sv;
                sv.nev = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out sv.mag);
                diakok.Add(sv);

            }
            /**/
            for (int i = 0; i < n; i++)
            {
                Tdiak sv;
                string? sor = Console.ReadLine();
                string[] sortomb = sor.Split(' ');
                sv.nev = sortomb[0];
                sv.mag = int.Parse(sortomb[1]);
                diakok.Add(sv);
            }
            for (int i = 0; i < diakok.Count - 1; i++)
            {
                if (diakok[i].mag <= diakok[i + 1].mag)
                {
                    ++db;
                    nevek.Add(diakok[i].nev);
                }
            }            
            Console.Write($"{nevek.Count} ilyen van: ");
            Console.WriteLine(String.Join(',', nevek));
            /**/
        }
    }
}
