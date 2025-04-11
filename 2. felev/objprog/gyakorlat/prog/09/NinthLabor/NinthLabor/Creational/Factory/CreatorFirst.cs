namespace NinthLabor.Creational.Factory
{
    public class CreatorFirst : Creator
    {
        public override IProduct Create()
        {
            return new ProductFirst();
        }
    }
}

