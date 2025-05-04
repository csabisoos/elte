namespace HF10
{
    public class M : Size
    {
        private static M? instance;
        
        private M () {}

        public static M Instance()
        {
            instance ??= new();
            return instance;
        }
        public int Multi()
        {
            return 2;
        }
    }
}

