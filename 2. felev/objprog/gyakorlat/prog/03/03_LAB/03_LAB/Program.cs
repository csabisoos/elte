namespace _03_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            FlexibleType number = new(63, Type.Number);
            FlexibleType character = new(63, Type.Character);
            FlexibleType boolean = new(63, Type.Boolean);
            Console.WriteLine(number);
            Console.WriteLine(character);
            Console.WriteLine(boolean);
        }
    }
}

