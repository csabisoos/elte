namespace _06_kisbeadando
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[0];
            int napi = 0;

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] array = line.Split(' ');

                    Szamla szamla = new Szamla { Nev = array[0] };

                    for (int i = 1; i < array.Length - 1; i += 2) 
                    {
                        string cikkszam = array[i];
                        string arString = array[i + 1];

                        int.TryParse(arString, out int ar);

                        szamla.lista.Add(new Termek { Cikkszam = cikkszam, Ar = ar });
                    }

                    napi += szamla.Osszegzes();
                }
            }

            Console.WriteLine(napi);
        }
    }
}