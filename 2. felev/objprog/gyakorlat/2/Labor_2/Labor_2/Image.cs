namespace Labor_2
{
    public class Image
    {
        // Fields
        private int width;
        private int height;
        private RGB[,] pixels;
        
        // Properties
        public int Width => width;
        public int Height => height;
        public RGB this[int col, int row]
        {
            get => pixels[col, row];
            set => pixels[col, row] = value;
        }
        
        // Constructors
        public Image(int width, int height, RGB[,] pixels)
        {
            this.width = width;
            this.height = height;
            this.pixels = pixels;
        }

        public Image(int width, int height)
        {
            this.width = width;
            this.height = height;
            pixels = new RGB[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixels[i, j] = new(0, 0, 0);
                }
            }
        }
        
        // Methods
        public void Inverse()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixels[i, j] = pixels[i, j].Inverse();
                }
            }
        }

        public void SumImage(Image image)
        {
            if (image.width != width || image.height != height)
                throw new ArgumentException("Different image sizes.");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixels[i, j] += image[i, j];
                }
            }
        }

        public void Grayscale()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixels[i, j] = pixels[i, j].Grayscale();
                }
            }
        }

        public void Multiply(Image image)
        {
            if (image.width != width || image.height != height)
                throw new ArgumentException("Different image sizes.");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pixels[i, j] *= image[i, j];
                }
            }
        }

        public void SaveImage(string path)
        {
            using StreamWriter writer = new(path);
            writer.WriteLine($"P3\n{width} {height}\n255");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    RGB pixel = pixels[y, x];
                    writer.Write($"{pixel.Red} {pixel.Green} {pixel.Blue} ");
                }
                writer.WriteLine();
            }
        }
    }
}