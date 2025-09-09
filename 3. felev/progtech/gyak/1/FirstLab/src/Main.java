import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        List<Hallgato> list = new ArrayList<>();
        Scanner sc = new Scanner(System.in);

        System.out.print("Hány hallgatót adsz meg? ");
        int n = sc.hasNextInt() ? sc.nextInt() : 0;
        sc.nextLine();

        for (int i = 0; i < n; i++) {
            System.out.print((i + 1) + ". hallgató neve: ");
            String name = sc.nextLine().trim();

            System.out.print((i + 1) + ". hallgató nemzete: ");
            String szak = sc.nextLine().trim();

            System.out.print((i + 1) + ". hallgató átlaga: ");
            String avgStr = sc.nextLine().trim().replace(',', '.');
            double avg = avgStr.isEmpty() ? 0.0 : Double.parseDouble(avgStr);

            list.add(new Hallgato(name, szak, avg));
        }

        if (list.isEmpty()) {
            System.out.println("Nincs adat.");
            return;
        }

        double max = list.getFirst().getAvg();
        String maxname = list.getFirst().getName();
        double min = list.getFirst().getAvg();
        String minname = list.getFirst().getName();

        for (Hallgato h : list) {
            if (h.getAvg() > max) {
                max = h.getAvg();
                maxname = h.getName();
            }
            if (h.getAvg() < min) {
                min = h.getAvg();
                minname = h.getName();
            }
        }

        System.out.println("Legjobb átlag: " + max + ", " + maxname);
        System.out.println("Legrosszabb átlag: " + min + ", " + minname);

        System.out.println("4.0 vagy jobb átlaggal rendelkezők:");
        for (Hallgato h : list) {
            if (h.getAvg() >= 4.0) {
                System.out.println(h.getName());
            }
        }
    }
}