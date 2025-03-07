using System.Diagnostics;

namespace FourthLabor
{
    public class Menu
    {
        private List<Folder> root;

        public Menu()
        {
            root = new();
        }

        public void Run()
        {
            string? input;

            do
            {
                Console.Clear();
                Console.WriteLine(
                    "Mappa menü:\n" +
                    "1. Kilistázás\n" +
                    "2. Megnyitás\n" +
                    "3. Létrehozás\n" +
                    "4. Törlés");
                
                input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        ListFolders();
                        Console.ReadKey(true);
                        break;
                    case "2":
                        OpenFolder();
                        Console.ReadKey(true);
                        break;
                    case "3":
                        string name = Console.ReadLine();
                        // if (name == null) name = "";
                        name ??= "";
                        CreateFolder(name);
                        Console.ReadKey(true);
                        break;
                    case "4":
                        DeleteFolder();
                        Console.ReadKey(true);
                        break;
                    default:
                        if (input != "exit")
                        {
                            Console.WriteLine("Hibás bemenet!");
                            Console.ReadKey(true);
                        }
                        break;
                }
            } while (input!="exit");
        }

        private void ListFolders()
        {
            for (int i = 0; i < root.Count; i++)
            {
                Console.WriteLine(root[i].Name);
            }
        }
        
        private void OpenFolder(string name)
        {
            (bool found, Folder folder) = SearchFolder(name);
            if (found)
            {
                for (int i = 0; i < folder.Files.Count; i++)
                {
                    Console.WriteLine(folder.Files[i].Name);
                }
            }
        }
        
        private void CreateFolder(string name)
        {
            if (name == "") name = "Új mappa";
            root.Add(new Folder(name));
        }
        
        private void DeleteFolder(string name)
        {
            (bool found, Folder? folder) = SearchFolder(name);

            if (found)
            {
                root.Remove(folder);
            }
        }

        private (bool, Folder?) SearchFolder(string name)
        {
            for (int i = 0; i < root.Count; i++)
            {
                if (root[i].Name == name)
                {
                    return (true, root[i]);
                }
            }

            return (false, null);
        }
    }
}

