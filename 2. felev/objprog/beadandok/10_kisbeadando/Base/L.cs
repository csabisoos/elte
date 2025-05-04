namespace HF10
{
    public class L : Size
    {
        private static L? instance;
        
        private L () {}

        public static L Instance()
        {
            instance ??= new();
            return instance;
        }
        public int Multi()
        {
            return 3;
        }
    }
}

