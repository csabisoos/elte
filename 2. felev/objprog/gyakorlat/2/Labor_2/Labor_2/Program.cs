namespace Labor_2
{
    class Program
    {
        static void Main(string[] args)
        {
            RGB rgb = new RGB(255, 0, 0);
            Console.WriteLine(rgb);
            Console.WriteLine(rgb.Inverse());
            Console.WriteLine(rgb.Grayscale());
            Console.WriteLine(rgb+rgb);
            Console.WriteLine(rgb*rgb);
            Console.WriteLine(rgb.IsSameColor(rgb));
            Console.WriteLine(RGB.IsSameColor(rgb, rgb));
            
            Image image = new Image(1000, 1000);
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    byte red = (byte)(i + j % 256);
                    byte green = (byte)(i + j % 256);
                    byte blue = (byte)(i + j % 256);
                    image[i, j] = new(red, green, blue);
                }
            }
            //image.Grayscale();
            //image.Inverse();
            image.SaveImage("result.ppm");
            Console.WriteLine("Done!");

        }
    }
}