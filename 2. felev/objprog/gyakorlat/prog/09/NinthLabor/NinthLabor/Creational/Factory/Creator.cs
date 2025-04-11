namespace NinthLabor.Creational.Factory
{
    public abstract class Creator
    {
        public void Method()
        {
            IProduct product = Create();
            product.Method();
        }

        public abstract IProduct Create();
    }
}

