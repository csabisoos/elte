namespace NinthLabor.Creational.Singleton
{
    public class Singleton
    {
        private static Singleton? instance;

        private Singleton() { }

        public static Singleton Instance()
        {
            instance ??= new();
            return instance;
        }

        public void Method()
        {
            Console.WriteLine(nameof(Singleton));
        }
    }
}

