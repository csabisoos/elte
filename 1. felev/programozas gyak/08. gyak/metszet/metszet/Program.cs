namespace metszet;

class Program
{
    static bool bennevan(int mit, List<int> miben, int meddig)
    {
        int i = 1;
        while (i <= meddig && mit != miben[i])
        {
            i = i + 1;
        }
        return i <= meddig;
    }
    static void Main(string[] args)
    {
        int db = 0;
        List<int> x = new List<int> { 1, 2, 3, 5, 6 };
        List<int> y = new List<int> { 2, 3, 1, 4};
        for(int i=0; i<x.Count(); ++i)
        {
            if (bennevan(x[i],y,y.Count()))
            {
                db = db + 1;
                y[db] = x[i];
            }
        }
        foreach(int elem in y)
        {
            Console.WriteLine(elem);
        }
    }
}

