namespace NinthLabor.Structural.Bridge
{
    public class ImplementationFirst : IImplementation
    {
        public void MethodFirst()
        {
            Console.WriteLine(nameof(Bridge) + ": " + nameof(ImplementationFirst) + ": " + nameof(MethodFirst));
        }

        public void MethodSecond()
        {
            Console.WriteLine(nameof(Bridge) + ": " + nameof(ImplementationFirst) + ": " + nameof(MethodSecond));
        }
    }
}

