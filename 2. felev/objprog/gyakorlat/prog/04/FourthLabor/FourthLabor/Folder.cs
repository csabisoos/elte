namespace FourthLabor
{
    public class Folder
    {
        public string Name { get; set; }
        public List<File> Files { get; }

        public Folder(string name)
        {
            Name = name;
            Files = new();
        }

        public void Add(File file)
        {
            Files.Add(file);
        }

        public void Remove(File file)
        {
            Files.Remove(file);
        }
    }
}

