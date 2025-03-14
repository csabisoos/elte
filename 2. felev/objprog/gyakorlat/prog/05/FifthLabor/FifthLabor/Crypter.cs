namespace FifthLabor
{
    public class Crypter
    {
        // Fields
        private short key;

        // Constructors
        public Crypter()
        {
            this.key = GenerateKey();
        }

        public Crypter(short key0)
        {
            this.key = key;
        }

        // Methods
        public void Encrypt(string inpath, string outpath)
        {
            using StreamReader reader = new(inpath);
            using StreamWriter writer = new(outpath);
            string text = reader.ReadToEnd();
            writer.Write(Encrypt(text));
        }

        public void Decrypt(string inpath, string outpath)
        {
            using StreamReader reader = new(inpath);
            using StreamWriter writer = new(outpath);
            string text = reader.ReadToEnd();
            writer.Write(Decrypt(text));
        }
        
        private string Encrypt(string text)
        {
            string encrypted = "";
            int length = text.Length;
            int[] crypted = new int[length + 1];
            int swap = key % (int)Math.Sqrt(length) + 1;
            crypted[length] = swap * key;

            for (int i = 0; i < length; i++)
            {
                crypted[i] = text[i] * key;
                if (i > 0 && i % swap == 0)
                {
                    Swap(ref crypted[i], ref crypted[i - swap + 1]);
                }
            }

            for (int i = 0; i < length+1; i++)
            {
                if (i > 0) encrypted += '\n';
                encrypted += crypted[i];
            }
            
            return encrypted;
        }
        
        private string Decrypt(string text)
        {
            string decrypted = "";
            string[] split = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length-1;
            int[] crypted = new int[length];
            int swap = int.Parse(split[length]) / key;

            for (int i = 0; i < length; i++)
            {
                crypted[i] = int.Parse(split[i]) / key;
                if (i > 0 && i % swap == 0)
                {
                    Swap(ref crypted[i], ref crypted[i-swap + 1]);
                }
            }

            for (int i = 0; i < length; i++)
            {
                decrypted += (char)crypted[i];
            }

            return decrypted;
        }
        
        private short GenerateKey()
        {
            Random random = new Random();
            return (short)random.Next(short.MaxValue);
        }

        private void Swap(ref int first, ref int second)
        {
            (first, second) = (second, first);
        }
    }
}

