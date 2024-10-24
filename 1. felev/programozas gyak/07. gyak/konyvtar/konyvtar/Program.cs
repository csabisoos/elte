namespace konyvtar
{
    class Program
    {
        struct Konyv
        {
            public string szerzo, cim;
            public int psz, kpsz;
        };
        static void Beolvas(int n, List<Konyv> k)
        {
            string[] sor;
            for (int i = 0; i < n; i++)
            {
                sor = Console.ReadLine().Split(' ');
                k.Add(new Konyv {
                    szerzo = sor[0],
                    cim = sor[1],
                    psz = int.Parse(sor[2]),
                    kpsz = int.Parse(sor[3])
                });
            }
        }
        static double AtlagSzamol()
        {

        }
        static void Kivalogat(int db, int[] tomb)
        {

        }        
        static void Main(string[] args)
        {
            int n, db;
            List<Konyv> k = new List<Konyv>();
            int.TryParse(Console.ReadLine(), out n);
            Beolvas(n, k);
            double avg = AtlagSzamol(...);
            (db, k) = Kivalogat(n,k,avg,ref db, ref mik);
            Kiir(k);
        }
    }
}

