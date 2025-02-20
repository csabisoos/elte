public class PointMain {
    public static void main(String[] args) {
        Point p = new Point(2.5, 3.1);
        printPoint(p);

        p.move(0.5, -1.1);
        printPoint(p);

        Point m = new Point(0, 0);
        Point s = new Point(1, 1);
        
        p.mirror(m);
        printPoint(p);

        System.out.println(s.distance(m));
    }

    public static void printPoint(Point p) {
        System.out.println("(%.2f, %.2f)".formatted(p.getX(), p.getY()));
    }
}