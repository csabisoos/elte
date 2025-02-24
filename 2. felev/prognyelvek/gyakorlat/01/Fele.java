public class Fele {
    public static void main(String[] args) {
        int elso = Integer.parseInt(System.console().readLine("Add meg az első számot: "));
        int masodik = Integer.parseInt(System.console().readLine("Add meg a második számot: "));
        if (elso < masodik)
        {
            for (int i = elso+1; i < masodik; ++i) {
                System.out.println(i/2.0);
            }
        }
        else {
            for (int i = elso-1; i > masodik; --i) {
                System.out.println(i/2.0);
            }
        }
    }
}