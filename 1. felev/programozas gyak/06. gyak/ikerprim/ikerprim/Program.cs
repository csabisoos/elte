namespace ikerprim
{
    internal class Program
    {
        static bool prim(int x) {
            int i = 2;
            while ((i <= (x - 1)) && (x%i != 0)) { i++; }
            return (i>(x-1));
        }
        static void Main(string[] args)
        {
            int k = 2, v = 5;
            int a, b;
            a = k;
            while (a<=(v-2) && !(prim(a) && prim(a+2))){
                ++a;            
            }
            if (a<=(v-2)){
                b = a + 2;
                Console.WriteLine($"a két ikerprím: {a} és {b}");
            } else { Console.WriteLine("nincs ebben az intervallumban ikerprim"); }
        }
    }
}
