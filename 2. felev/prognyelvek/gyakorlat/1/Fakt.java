public class Fakt {
    public static void main(String[] args) {
        int n = Integer.parseInt(System.console().readLine("Adj meg egy számot és kiszámolom a faktoriálisát: "));
        if (n<0) {
            System.out.println("A szám nem lehet negatív!");
            return;
        }
        long faktorialis = 1;
        for (int i = 1; i <= n; ++i) {
            faktorialis *= i;
        }
        System.out.println(n + " faktoriálisa: " + faktorialis);
    }
}