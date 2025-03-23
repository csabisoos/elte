namespace _05_kisbeadando;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            // Console.WriteLine("Használat: Program <input file>");
            return;
        }

        string filePath = args[0];
        if (!File.Exists(filePath))
        {
            // Console.WriteLine("A megadott fájl nem létezik!");
            return;
        }

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                double sum = 0.0;
                int count = 0;
                bool belowFreezing = false;
                bool allBelowFreezing = true;
                double minTemp = double.MaxValue;
                    
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (double.TryParse(line, out double temp))
                    {
                        if (!belowFreezing)
                        {
                            if (temp < 0)
                            {
                                belowFreezing = true;
                            }
                            else
                            {
                                sum += temp;
                                count++;
                            }
                        }
                            
                        if (belowFreezing)
                        {
                            if (temp>=0)
                            {
                                allBelowFreezing = false;
                            }
                            if (temp < minTemp)
                            {
                                minTemp = temp;
                            }
                        }
                    }
                }
    
                if (count > 0)
                {
                    double avg = sum / count;
                    Console.WriteLine(avg); // Átlaghőmérséklet a fagy alatti érték előtti napokra
                }
                else
                {
                    Console.WriteLine("Nem volt pozitív hőmérsékletű nap a fagy előtt.");
                }

                Console.WriteLine(allBelowFreezing);
                Console.WriteLine(minTemp); // Legkisebb hőmérséklet a fagy után
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt: {ex.Message}");
        }
    }
}