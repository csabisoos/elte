import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import static java.lang.Math.round;

public class Main {
    public static void main(String[] args) {
        String fileName = promptForExistingFileName();
        List<PlaneFigure> figures = load(fileName);
        for (PlaneFigure f : figures) {
            try {
                System.out.println(f + " | difference=" + round(f.difference() * 100.0) / 100.0);
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }
        }

        PlaneFigure minDiff = null;
        double minVal = Double.POSITIVE_INFINITY;
        for (PlaneFigure f : figures) {
            try {
                double d = f.difference();
                if (d < minVal) {
                    minVal = d;
                    minDiff = f;
                }
            } catch (Exception ignored) {
            }
        }
        if (minDiff != null) {
            try {
                System.out.println("\n" + "Min difference: " + minDiff + " | difference=" + round(minDiff.difference() * 100.0) / 100.0);
            } catch (Exception e) {
                System.out.println("Error while printing the minimum-difference figure: " + e.getMessage());
            }
        } else {
            System.out.println("No valid figure available to determine minimum difference.");
        }
    }

    private static List<PlaneFigure> load(String fileName) {
        List<PlaneFigure> list = new ArrayList<>();
        List<String> lines;
        try {
            lines = Files.readAllLines(Path.of(fileName));
        } catch (Exception e) {
            return list;
        }
        if (lines.isEmpty()) return list;

        int expectedCount;
        try {
            String first = lines.get(0).trim();
            if (first.isEmpty()) return list;
            expectedCount = Integer.parseInt(first);
            if (expectedCount < 0) {
                return list;
            }
        } catch (NumberFormatException e) {
            return list;
        }

        int created = 0;
        for (int i = 1; i < lines.size() && created < expectedCount; i++) {
            String line = lines.get(i).trim();
            if (line.isEmpty()) continue;
            String[] p = line.split("\\s+");
            if (p.length != 4) continue;
            try {
                String t = p[0];
                double x = Double.parseDouble(p[1]);
                double y = Double.parseDouble(p[2]);
                double size = Double.parseDouble(p[3]);

                PlaneFigure f = switch (t) {
                    case "C" -> new Circle(x, y, size);
                    case "T" -> new Triangle(x, y, size);
                    case "S" -> new Square(x, y, size);
                    case "H" -> new Hexagon(x, y, size);
                    default -> null;
                };
                if (f != null) {
                    list.add(f);
                    created++;
                }
            } catch (Exception ignored) {
            }
        }
        return list;
    }

    private static String promptForExistingFileName() {
        Scanner sc = new Scanner(System.in);
        while (true) {
            System.out.print("Enter input file name (e.g. figures.txt) or type 'exit' to quit: ");
            String name = sc.nextLine().trim();
            if (name.equalsIgnoreCase("exit")) {
                System.out.println("Exiting program.");
                System.exit(0);
            }
            if (name.isEmpty()) {
                System.out.println("Filename cannot be empty.");
                continue;
            }
            Path p = Path.of(name);
            if (Files.isRegularFile(p) && Files.isReadable(p)) {
                return name;
            }
            System.out.println("File not found or not readable: " + name);
        }
    }
}