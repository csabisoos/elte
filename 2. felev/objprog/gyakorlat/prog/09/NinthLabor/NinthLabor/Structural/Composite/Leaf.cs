namespace NinthLabor.Structural.Composite
{
    public class Leaf : IElement
    {
        public void Method()
        {
            Console.WriteLine(nameof(Composite) + ": " + nameof(Leaf));
        }
    }
}

