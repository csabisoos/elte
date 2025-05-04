namespace HF10
{
    public class XL : Size
    {
        private static XL? instance;
        
        private XL () {}

        public static XL Instance()
        {
            instance ??= new();
            return instance;
        }
        public int Multi()
        {
            return 4;
        }
    }
}

