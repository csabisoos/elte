namespace HF1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            string[] separatedLine = Console.ReadLine().Split();
            n = int.Parse(separatedLine[0]);
            m = int.Parse(separatedLine[1]);
            Content[,] map = new Content[n, m];
            Content placeholder;
            for(int i = 0; i < n; i++)
            {
                separatedLine = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    switch (separatedLine[j]) 
                    {
                        case "Üres":
                            placeholder = Content.Empty;
                            map[i, j] = placeholder;
                            break;
                        case "Fal":
                            placeholder = Content.Wall;
                            map[i, j] = placeholder;
                            break; 
                        case "Kincs": 
                            placeholder = Content.Treasure;
                            map[i, j] = placeholder;
                            break; 
                        case "Szellem":
                            placeholder = Content.Ghost;
                            map[i, j] = placeholder;
                            break;
                    }
                }
            }
            Labirynth labirynth = new Labirynth(map);
            int x, y;
            try
            {
                separatedLine = Console.ReadLine().Split();
                x = int.Parse(separatedLine[0]);
                y = int.Parse(separatedLine[1]);
                labirynth.Collect(x, y);
                Console.WriteLine("Sikerült begyűjteni");
            }
            catch (Exception e)
            {
                Console.WriteLine("Nem sikerült a begyűjtés");
            }
            try
            {
                separatedLine = Console.ReadLine().Split();
                x = int.Parse(separatedLine[0]);
                y = int.Parse(separatedLine[1]);
                Direction dir = new Direction();
                separatedLine = Console.ReadLine().Split();
                dir.x = int.Parse(separatedLine[0]);
                dir.y = int.Parse(separatedLine[1]);
                Content result = labirynth.LookAt(x, y, dir);
                if (result == Content.Treasure)
                    Console.WriteLine("Kincs");
                else if (result == Content.Wall)
                    Console.WriteLine("Fal");
                else if (result == Content.Empty)
                    Console.WriteLine("Üres");
                else
                    Console.WriteLine("Szellem");
            }
            catch (Exception e)
            {
                Console.WriteLine("Nem sikerült megtekinteni a tartalmat");
            }
        }
    }
}
