namespace SixthLabor
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader reader = new FileReader(@"/Users/csabasoos/Desktop/elte/2. felev/objprog/gyakorlat/prog/06/SixthLabor/SixthLabor/Input.txt");
            Equations equations = reader.ReadFile();
            Console.WriteLine(equations.CountOperand(2));
            Console.WriteLine(equations.CountOperator(Operators.Addition));
        }
    }
}

