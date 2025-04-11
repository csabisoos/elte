namespace NinthLabor.Structural.Bridge
{
    public class ImplementationSecond : IImplementation
    {
        public void MethodFirst()
        {
            Console.WriteLine(nameof(Bridge) + ": " + nameof(ImplementationSecond) + ": " + nameof(MethodFirst));
        }

        public void MethodSecond()
        {
            Console.WriteLine(nameof(Bridge) + ": " + nameof(ImplementationSecond) + ": " + nameof(MethodSecond));
        }
    }
}

