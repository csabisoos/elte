namespace NinthLabor.Structural.Bridge
{
    public class Abstraction
    {
        private IImplementation implementation;

        public Abstraction(IImplementation implementation)
        {
            this.implementation = implementation;
        }

        public void Method()
        {
            implementation.MethodFirst();
            implementation.MethodSecond();
        }
    }
}

