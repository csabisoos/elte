using System.ComponentModel.DataAnnotations;

namespace FifthLabor
{
    public class Analyzer
    {
        private List<int> elements;

        public Analyzer(string path)
        {
            elements = [];
            ProcessFile(path);
        }

        public int Max()
        {
            return elements.Max();
        }

        public int Min()
        {
            return elements.Min();
        }

        public int Count(int element)
        {
            return elements.Count(e => e == element);
        }

        private void ProcessFile(string path)
        {
            using StreamReader reader = new(path);
            string line;
                
            while (!(reader.EndOfStream))
            {
                line = reader.ReadLine();
                elements.Add(int.Parse(line));
            }
        }
    }
}

