namespace _06_kisbeadando
{
    public class Szamla
    {
        public string Nev { get; set; }
        public List<Termek> lista { get; set; } = new List<Termek>();

        public int Osszegzes()
        {
            return lista.Sum(termek => termek.Ar);
        }
    }
}

