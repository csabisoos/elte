namespace HF10
{
    public class S : Size
    {
        private static S? instance;
        
        private S () {}

        public static S Instance()
        {
            instance ??= new();
            return instance;
        }
        
        public int Multi()
        {
            return 1;
        }
    }
}

