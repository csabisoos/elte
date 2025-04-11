namespace NinthLabor.Creational.Factory
{
    public class ProductFirst : IProduct
    {
        public void Method()
        {
            Console.WriteLine(nameof(Factory) + ": " + nameof(ProductFirst));
        }
    }
}

