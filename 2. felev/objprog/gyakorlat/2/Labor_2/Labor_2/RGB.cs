namespace Labor_2
{
    public readonly struct RGB
    {
        // Fields
        private readonly byte red;
        private readonly byte green;
        private readonly byte blue;

        // Properties
        public readonly byte Red => red;
        public readonly byte Green => green;
        public readonly byte Blue => blue;
        
        // Constructors
        public RGB(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        
        // Methods
        public RGB Inverse()
        {
            return new RGB((byte)(255 - red), 
                         (byte)(255 - green), 
                          (byte)(255 - blue));
        }

        public RGB Grayscale()
        {
            byte average = (byte)((red+green+blue)/3);
            return new RGB(average, average, average);
        }

        public bool IsSameColor(RGB rgb)
        {
            return red - rgb.red == green - rgb.green && green - rgb.green == blue - rgb.blue;
        }

        public static bool IsSameColor(RGB first, RGB second)
        {
            return first.red - second.red == first.green - second.green &&
                   first.green - second.green == first.blue - second.blue;
        }

        public static RGB operator +(RGB first, RGB second)
        {
            return new RGB((byte)((first.red + second.red) / 2), 
                         (byte)((first.green + second.green) / 2),
                          (byte)((first.blue + second.blue) / 2));
        }

        public override string ToString()
        {
            return $"({red}, {green}, {blue})";
        }

        public static RGB operator *(RGB first, RGB second)
        {
            return new RGB((byte)((first.red * second.red) / 255), 
                (byte)((first.green * second.green) / 255),
                (byte)((first.blue * second.blue) / 255));
        }
    }
}