using System.Globalization;
using Library.Books;
using Library.Models;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraries = new List<Models.Library>();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
            LoadLibrariesFromFile(path, libraries);
            Console.WriteLine($"\n✅ Betöltés kész. Könyvtárak száma: {libraries.Count}");
        }
        
        static void LoadLibrariesFromFile(string path, List<Models.Library> libraries)
        {
            Models.Library currentLibrary = null;
    
            foreach (var line in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
    
                string[] parts = line.Split(';');
    
                switch (parts[0])
                {
                    case "Library" when parts.Length == 2:
                        Console.WriteLine($"\n📚 Könyvtár létrehozása: {parts[1]}");
                        currentLibrary = new Models.Library();
                        libraries.Add(currentLibrary);
                        Console.WriteLine("✅ Könyvtár létrehozva.");
                        break;
    
                    case "Member" when parts.Length == 6 && currentLibrary != null:
                        try
                        {
                            var memberId = parts[1];
                            var name = parts[2];
                            var address = parts[3];
                            var registrationDate = DateTime.Parse(parts[4], CultureInfo.InvariantCulture);
                            var expiryDate = DateTime.Parse(parts[5], CultureInfo.InvariantCulture);
    
                            var member = new Member(memberId, name, address, registrationDate, expiryDate);
    
                            Console.WriteLine($"\n👤 Tag hozzáadása: {name} ({memberId})");
                            currentLibrary.RegisterMember(member);
                            Console.WriteLine("✅ Tag regisztrálva.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Hibás tag sor: {line}\n➡ {ex.Message}");
                        }
                        break;
    
                    case "Book" when parts.Length == 7 && currentLibrary != null:
                        try
                        {
                            string type = parts[1];
                            string title = parts[2];
                            string author = parts[3];
                            string publisher = parts[4];
                            string isbn = parts[5];
                            int copies = int.Parse(parts[6]);
    
                            Book book = type switch
                            {
                                "Literature" => new LiteratureBook(title, author, publisher, isbn, 0),
                                "Science"    => new ScienceBook(title, author, publisher, isbn, 0),
                                "Youth"      => new YouthBook(title, author, publisher, isbn, 0),
                                _ => throw new InvalidOperationException($"Ismeretlen könyvtípus: {type}")
                            };
    
                            Console.WriteLine($"\n📖 Könyv hozzáadása: {book}");
                            Console.WriteLine("📦 Könyvtár állapota a hozzáadás előtt:");
                            foreach (var b in currentLibrary.GetAllBooks())
                                Console.WriteLine($"- {b}");
    
                            currentLibrary.AddBook(book, copies);
    
                            Console.WriteLine("✅ Könyv hozzáadva.");
                            Console.WriteLine("📦 Könyvtár állapota a hozzáadás után:");
                            foreach (var b in currentLibrary.GetAllBooks())
                                Console.WriteLine($"- {b}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Hibás könyv sor: {line}\n➡ {ex.Message}");
                        }
                        break;
    
                    default:
                        Console.WriteLine($"⚠️ Ismeretlen vagy hibás sor: {line}");
                        break;
                }
            }
        }
    }
}

