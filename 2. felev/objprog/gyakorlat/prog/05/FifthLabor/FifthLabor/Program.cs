namespace FifthLabor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"/Users/csabasoos/Desktop/elte/2. felev/objprog/gyakorlat/prog/05/FifthLabor/FifthLabor/Text.txt";
            string encrypted = @"/Users/csabasoos/Desktop/elte/2. felev/objprog/gyakorlat/prog/05/FifthLabor/FifthLabor/Encrypted.txt";
            string decrypted = @"/Users/csabasoos/Desktop/elte/2. felev/objprog/gyakorlat/prog/05/FifthLabor/FifthLabor/Decrypted.txt";

            Crypter crypter = new();
            
            string? input;
            do
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Titkosítás \n" +
                    "2. Visszafejtés \n" +
                    "3. Elemzés \n" +
                    "4. Kilépés \n");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        crypter.Encrypt(text, encrypted);
                        break;
                    case "2":
                        crypter.Decrypt(encrypted, decrypted);
                        break;
                    case "3":
                        Console.WriteLine(
                            "1. Max \n" +
                            "2. Min \n" +
                            "3. Count \n");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        break;
                    default:
                        if (input != "4") Console.WriteLine("Helytelen bemenet!");
                        Console.ReadKey(true);
                        break;
                }
            } while (input != "4");
        }
    }
}

