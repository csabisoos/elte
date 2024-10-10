namespace monno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            int[] sorozat = new int[n];
            /** /
            string sv = Console.ReadLine();
            string[] ssv = sv.Split(" ");
            /**/
            string[] ssv = Console.ReadLine().Split(" ");
            for (int i = 0; i < ssv.Length; i++)
            {
                sorozat[i] = int.Parse(ssv[i]);
            }
            bool monno = false;
            int k = 0;
            while (k < n-1 && !(sorozat[k] > sorozat[k + 1]))
            {
                k += 1;
            }
            monno = (k == n - 1);
            Console.WriteLine(monno);
        }
    }
}
