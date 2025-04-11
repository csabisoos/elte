namespace NinthLabor.Creational.Factory
{
    public class ProductSecond : IProduct
    {
        public void Method()
        {
            Console.WriteLine(nameof(Factory) + ": " + nameof(ProductSecond));
        }
    }
}

