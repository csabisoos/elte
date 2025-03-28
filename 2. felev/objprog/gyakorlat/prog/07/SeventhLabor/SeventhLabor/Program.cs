using SeventhLabor.Terrains;

namespace SeventhLabor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Field f = new Field();
            Lake l = new Lake();
            Mountain m = new Mountain();
            Terrain[,] terrains = new Terrain[,]
            {
                {f, f, m, m},
                {f, f, f, m},
                {l, l, f, f},
                {l, l, l, l},
            };
            Model model = new(terrains, 0, 0);

            View view = new(model);
            view.Run();
        }
    }
}

