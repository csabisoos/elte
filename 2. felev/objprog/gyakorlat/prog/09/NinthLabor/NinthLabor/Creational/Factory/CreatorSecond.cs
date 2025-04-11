namespace NinthLabor.Creational.Factory
{
    public class CreatorSecond : Creator
    {
        public override IProduct Create()
        {
            return new ProductSecond();
        }
    }
}

