namespace SixthLabor
{
    public class FileReader
    {
        // Fields
        private readonly StreamReader reader;
        
        // Constructors
        public FileReader(string filePath)
        {
            reader = new(filePath);
        }
        
        // Methods
        public Equations ReadFile()
        {
            Equations equations = new Equations();

            while (!reader.EndOfStream)
            {
                equations.Add(ReadLine()!);
            }
            
            reader.Close();

            return equations;
        }
        
        private Equation? ReadLine()
        {
            if (reader.EndOfStream) return null;

            string line = reader.ReadLine()!;
            char[] seperators = [' ', '\t'];
            string[] split = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            Equation? equation = new(double.Parse(split[0]));
            for (int i = 1; i < split.Length-1; i+=2)
            {
                Operation operation = new(
                    ParseOperator(split[i]), 
                    double.Parse(split[i + 1]));
                equation.Add(operation);
            }

            return equation;
        }

        private Operators ParseOperator(string text)
        {
            switch (text)
            {
                case "+":
                    return Operators.Addition;
                case "-":
                    return Operators.Subtraction;
                case "*":
                    return Operators.Multiplication;
                case "/":
                    return Operators.Division;
                default:
                    throw new FormatException("Cannot parse given string into an operator.");
                    break;
            }
        }
    }
}

